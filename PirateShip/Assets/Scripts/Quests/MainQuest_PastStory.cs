using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class MainQuest_PastStory : Quest
{
    public override void Update()
    {
        if(DialogueLua.GetVariable("PastPartiallyTold").AsBool == true || DialogueLua.GetVariable("PastFullyTold").AsBool == true)
        {
            completed = true;
        }
        base.Update();
    }
}
