using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class MainQuest_PirateAttackOpening : Quest
{
    public GameObject cutscene;
    private PlayerMovement pm;

    public override void Start()
    {
        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        base.Start();
    }

    public override void Update()
    {

        if(DialogueLua.GetVariable("PirateAttackOpeningCompleted").AsBool == true)
        {
            completed = true;
            pm.enabled = false;
            cutscene.SetActive(true);
        }
        base.Update();
    }
}
