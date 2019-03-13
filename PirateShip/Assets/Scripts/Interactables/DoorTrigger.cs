using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Door door;
    // Start is called before the first frame update
    public void TriggerDoor()
    {
        door.OpenDoors();
    }

    
}
