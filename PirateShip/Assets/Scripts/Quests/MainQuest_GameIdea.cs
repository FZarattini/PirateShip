using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class MainQuest_GameIdea : Quest
{ 

    public override void Update()
    {
        
        if(DialogueLua.GetVariable("GameIdeaHelpful").asBool == true || DialogueLua.GetVariable("GameIdeaNotHelpful").asBool == true)
        {
            completed = true;
        }

        base.Update();
    }
}
