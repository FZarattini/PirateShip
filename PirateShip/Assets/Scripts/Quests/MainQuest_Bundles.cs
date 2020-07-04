using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class MainQuest_Bundles : Quest
{

    public Item shinyBundle;
    public MineSceneController msc;

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        if (inventory.items.Contains(shinyBundle) && inventory.slots[inventory.items.IndexOf(shinyBundle)].quantity == 5)
        {
            DialogueLua.SetVariable("MainQuest_HasBundles", true);
        }

        if (inventory.items.Contains(shinyBundle) && inventory.slots[inventory.items.IndexOf(shinyBundle)].quantity > 5)
        {
            DialogueLua.SetVariable("MainsQuest_OverBundles", true);
        }

        if (DialogueLua.GetVariable("MainQuest_Bundles_Complete").AsBool == true)
        {
            completed = true;
        }

        if (completed)
        {
            msc.sceneCompleted = true;
        }
        base.Update();
    }

}
