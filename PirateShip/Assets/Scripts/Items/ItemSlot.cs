using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{

    public Image icon;
    public Item item;
    public float quantity = 0;
    public bool selected;
    public bool empty;

    private void Awake()
    {
        selected = false;
        empty = true;
    }

    private void Update()
    {
        if (selected)
        {
            gameObject.GetComponentInChildren<Image>().color = Color.gray;
        }
        else
        {
            gameObject.GetComponentInChildren<Image>().color = Color.white;
        }
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
        empty = false;
        icon.sprite = item.icon;
        icon.enabled = true;
    }
    
    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }

    public void toggleSelected()
    {
        if (!empty)
        {
            selected = !selected;
        }
    }

}
