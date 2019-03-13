using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
    private bool pickedUp;

    public override void Interact()
    {

        base.Interact();
        PickUp();
    }

    void PickUp()
    {
        pickedUp = Inventory.instance.Add(item);
        if (pickedUp)
        {
            Destroy(gameObject);

        }
    }

    private void Update()
    {
        Debug.Log("pode interagir" + canInteract);
        if (Input.GetKeyDown(KeyCode.E) && canInteract == true)
        {
            Interact();
        }
    }
}
