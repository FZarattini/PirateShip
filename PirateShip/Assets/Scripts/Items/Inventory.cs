using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Duas instancias de inventario geradas!");
            return;
        }
        instance = this;
    }
    #endregion

    public Transform itemsParent;
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    ItemSlot[] slots;

    public int space;

    public List<Item> items = new List<Item>();

    private void Start()
    {
        slots = itemsParent.GetComponentsInChildren<ItemSlot>();
    }

    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("Not enough space!");
                return false;
            }

            items.Add(item);

            if (onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
        }
        return true;
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
    /*
    public void Remove(Item item)
    {
        items.Remove(item);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }*/
}
