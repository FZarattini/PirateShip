using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractedNPCs : MonoBehaviour
{

    public NPCController[] npcList;

    public void CheckInteractions()
    {
        foreach(NPCController n in npcList)
        {
            if(n.interacted == true)
            {
                Openness.RegisterNPC();
            }
        }
    }

}
