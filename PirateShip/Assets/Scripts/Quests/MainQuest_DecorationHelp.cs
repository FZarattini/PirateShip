using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class MainQuest_DecorationHelp : Quest
{
    public override void Update()
    {

        if (DialogueLua.GetVariable("DecorationAccepted").AsBool == true || DialogueLua.GetVariable("DecorationRejected").AsBool == true) {
            completed = true;
        }
        else if(DialogueLua.GetVariable("DecorationOnHold").AsBool == true)
        {
            accepted = true;
        }
       
        base.Update();
    }
}
