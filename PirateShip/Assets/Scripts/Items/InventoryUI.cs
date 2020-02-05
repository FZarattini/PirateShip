using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    Inventory inventory;
    ItemSlot[] slots;

    // Start is called before the first frame update
    void Awake()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<ItemSlot>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
                slots[i].transform.GetChild(1).GetComponent<Text>().text = slots[i].quantity.ToString();
                slots[i].transform.GetChild(1).GetComponent<Text>().color = Color.black;
            }
            else
            {
                slots[i].ClearSlot();
            }

            if(slots[i].quantity == 0)
            {
                slots[i].transform.GetChild(1).GetComponent<Text>().text = "";
            }
        }
    }

}
