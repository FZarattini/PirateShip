using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class MainQuest_ExerciseBuddy : Quest
{
    public override void Update()
    {
        if (DialogueLua.GetVariable("ExerciseAccepted").AsBool == true || DialogueLua.GetVariable("ExerciseRejected").AsBool == true)
        {
            completed = true;
        }

        base.Update();
    }
}
