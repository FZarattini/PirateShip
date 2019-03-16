using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Canvas inventory;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            toggleInventory();
        }
    }

    private void toggleInventory()
    {
        if (!inventory.isActiveAndEnabled)
        {
        inventory.gameObject.SetActive(true);

        }
        else
        {
            inventory.gameObject.SetActive(false);
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ItemPickup>() != null)
        {
            collision.gameObject.GetComponent<ItemPickup>().canInteract = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ItemPickup>() != null)
        {
            collision.gameObject.GetComponent<ItemPickup>().canInteract = false;
        }
    }
}
