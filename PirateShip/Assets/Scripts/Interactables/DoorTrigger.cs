using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Door door;
    public bool locked;
    public bool interacted = false;

    // Start is called before the first frame update
    public void TriggerDoor(string animationName)
    {
        if(locked == false)
        {
            Debug.Log("Pode teleportar");
            PlayerController.canTeleport = true;
            Debug.Log("Abrindo portas!");
            door.OpenDoors(animationName);
            interacted = true;
        }
    }
    
    public void EndDoorAction(string animationName)
    {
        door.CloseDoors(animationName);
    }
}
