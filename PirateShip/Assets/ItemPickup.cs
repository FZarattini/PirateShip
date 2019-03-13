using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;

    public override void Interact()
    {

        base.Interact();
        PickUp();
    }

    void PickUp()
    {

        Destroy(gameObject);
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
