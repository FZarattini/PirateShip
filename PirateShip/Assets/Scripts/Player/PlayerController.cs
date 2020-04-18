using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Personality personality;
    public static bool canTeleport {get; set;}

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void TeleportPlayer(Transform destination)
    {
        if(canTeleport == true)
        {
            gameObject.transform.position = destination.position;
        }
        canTeleport = false;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ItemPickup>() != null)
        {
            collision.gameObject.GetComponent<ItemPickup>().canInteract = true;
        }

        if(collision.gameObject.tag == "Ladder")
        {
            //gameObject.GetComponent<PlayerMovement>().onLadder = true;
            gameObject.GetComponent<CharacterController2D>().SetOnLadder(true);    
        }

        if(collision.gameObject.tag == "Carriable")
        {
            collision.gameObject.GetComponent<Carriable>().SetPlayer(gameObject.transform);
            collision.gameObject.GetComponent<Carriable>().SetCanEquip(true);
            collision.gameObject.GetComponent<Carriable>().SetCanEquip(true);
                      
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ItemPickup>() != null)
        {
            collision.gameObject.GetComponent<ItemPickup>().canInteract = false;
        }
        if(collision.gameObject.tag == "Ladder")
        {
            //gameObject.GetComponent<PlayerMovement>().onLadder = false;
            gameObject.GetComponent<CharacterController2D>().SetOnLadder(false);
        }

        if (collision.gameObject.tag == "Carriable")
        {
            collision.gameObject.GetComponent<Carriable>().SetCanEquip(false);

        }
    }


}
