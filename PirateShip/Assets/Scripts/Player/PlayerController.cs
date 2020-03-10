﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Personality personality;    

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
     
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
    }
}
