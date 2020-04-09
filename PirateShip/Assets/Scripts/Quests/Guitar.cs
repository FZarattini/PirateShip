using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class Guitar : Quest
{
    public Inventory inventory;
    public Item guitar;
    public DialogueSystemTrigger npcDialogue;

    public override void Update()
    {
        base.Update();

        // If player collected the watch 

        if(DialogueLua.GetVariable("GuitarQuestAccepted").AsBool == true){
            accepted = true;
        }

        if (inventory.items.Contains(guitar))
        {
            DialogueLua.SetVariable("HasGuitar", true);
        }

        // If watch is delivered = Quest completed
        if ((DialogueLua.GetVariable("GuitarDelivered").AsBool) == true && completed == false)
        {
            inventory.Remove(guitar);
            DialogueLua.SetVariable("HasGuitar", false);
            completed = true;
            npcDialogue.enabled = false;
        }
    }
}
