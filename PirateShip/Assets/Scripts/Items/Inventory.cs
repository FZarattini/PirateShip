using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;
    public Transform itemsParent;

    private void Awake()
    {
        //itemsParent = GameObject.Find("itemsParent").GetComponent<Transform>();

        if (instance != null)
        {
            Debug.Log("Duas instancias de inventario geradas!");
            return;
        }
        instance = this;
    }
    #endregion

    public Transform hierarchy;
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    public Transform playerTransform;
    public GameObject prefab;
    

    private GameObject instantiated;
    private int index;

    ItemSlot[] slots;

    public int space;

    public List<GameObject> prefabs = new List<GameObject>();
    public List<Item> items = new List<Item>();

    private void Start()
    {
        slots = itemsParent.GetComponentsInChildren<ItemSlot>();

    }

    private void Update()
    {
        if(playerTransform == null){
            playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
        if(hierarchy == null)
        {
            hierarchy = GameObject.FindGameObjectWithTag("Items").GetComponent<Transform>();
        }
    }

    public bool Add(Item item)
    {
        int index;
        if (!item.isDefaultItem)
        {
            if (items.Contains(item))
            {
                index = items.IndexOf(item);
                Debug.Log("INDEX " + index);
                slots[index].quantity++;

                if (onItemChangedCallback != null)
                {
                    onItemChangedCallback.Invoke();
                }

                return true;
            }

            if (items.Count >= space && item)
            {
                Debug.Log("Not enough space!");
                return false;
            }

            items.Add(item);
            index = items.IndexOf(item);
            slots[index].quantity++;


            if (onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
        }
        return true;
    }

    public void DropSelectedItems()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].selected)
            {
                //index = items.IndexOf(slots[i].item);
                prefab = prefabs.Find(x => x.name.Equals(slots[i].item.name));
                instantiated = Instantiate(prefab, playerTransform.position, Quaternion.identity);
                instantiated.transform.SetParent(hierarchy);
               
                slots[i].selected = false;

                if (slots[i].quantity > 1)
                {
                    slots[i].quantity -= 1;
                }
                else
                {
                    items.Remove(slots[i].item);
                    slots[i].quantity = 0;
                    slots[i].empty = true;
                }
            }
        }

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }

    }

    public void RemoveSelectedItems()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].selected)
            {
                items.Remove(slots[i].item);
                slots[i].selected = false;
                slots[i].empty = true;
            }
        }

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }

    public void Remove(Item item)
    {

        items.Remove(item);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
}
