using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Door door;
    public bool locked;

    // Start is called before the first frame update
    public void TriggerDoor()
    {
        if(locked == false)
            door.OpenDoors();
    }   
}
