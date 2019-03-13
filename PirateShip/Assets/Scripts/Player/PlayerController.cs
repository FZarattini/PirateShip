using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<ItemPickup>() != null)
        {
            collision.gameObject.GetComponent<ItemPickup>().canInteract = true;
            
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<ItemPickup>() != null)
        {
            collision.gameObject.GetComponent<ItemPickup>().canInteract = false;
        }
    }*/


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
