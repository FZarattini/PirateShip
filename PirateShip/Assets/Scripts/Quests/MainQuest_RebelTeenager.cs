using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class MainQuest_RebelTeenager : Quest
{

    public Transform samNPC;
    public float npcSpeed;
    public Transform target;
    public Transform finalPosition;
    private Vector3 dirNormalized;
    public PlayerMovement pm;

    public override void Start()
    {
        dirNormalized = (target.position - samNPC.transform.position).normalized;
    }

    public override void Update()
    {
        if (DialogueLua.GetVariable("VillagerSonAccepted").AsBool == true)
        {
            accepted = true;
        }

        if (DialogueLua.GetVariable("VillagerSonCompleted").AsBool == true)
        {
            completed = true;

            if (samNPC.transform.position.x < target.transform.position.x)
            {
                pm.enabled = true;
                samNPC.transform.position = finalPosition.position;
            }
            else
            {
                pm.enabled = false;
                if (samNPC.transform.localScale.x < 0)
                {
                    samNPC.transform.localScale = new Vector3((-1) * samNPC.transform.localScale.x, samNPC.transform.localScale.y, samNPC.transform.localScale.z);
                }
                samNPC.transform.position = samNPC.transform.position + dirNormalized * npcSpeed * Time.deltaTime;
            }
                
        }       

        if (DialogueLua.GetVariable("VillagerSonFailed").AsBool == true)
        {
            failed = true;
        }

        base.Update();
    }
}
