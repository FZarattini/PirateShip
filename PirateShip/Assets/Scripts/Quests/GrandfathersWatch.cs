using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class GrandfathersWatch : Quest
{

    public Inventory inventory;
    public Item watch;

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        // If player collected the watch 

        if (DialogueLua.GetVariable("WatchQuestAccepted").AsBool == true){
            accepted = true;
        }

        if (inventory.items.Contains(watch))
        {
            DialogueLua.SetVariable("HasWatch", true);
        }

        // If watch is delivered = Quest completed
        if((DialogueLua.GetVariable("WatchDelivered").AsBool) == true && completed == false)
        {
            inventory.Remove(watch);
            DialogueLua.SetVariable("HasWatch", false);
            //DialogueLua.SetVariable("WatchDelivered", true);
            completed = true;
        }
    }
}
