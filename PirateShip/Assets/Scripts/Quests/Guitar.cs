using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class Guitar : Quest
{
    public Item guitar;
    public Item key;
    public DialogueSystemTrigger npcDialogue;
    public Animator npcAnim;
    public Usable npcUsable;
    public DoorTrigger dt;

    private bool keyAdded = false;

    public override void Update()
    {
        base.Update();

        // If player collected the Guitar
        if (dt.interacted == true)
        {
            inventory.Remove(key);
        }

        //!inventory.items.Contains(key)
        if (DialogueLua.GetVariable("GuitarQuestAccepted").AsBool == true && !keyAdded){
            accepted = true;
            dt.locked = false;
            keyAdded = inventory.Add(key);
        }

        if (inventory.items.Contains(guitar))
        {
            DialogueLua.SetVariable("HasGuitar", true);
        }

        // If Guitar is delivered = Quest completed
        if ((DialogueLua.GetVariable("GuitarDelivered").AsBool) == true && completed == false)
        {
            inventory.Remove(guitar);
            DialogueLua.SetVariable("HasGuitar", false);
            completed = true;
            npcDialogue.enabled = false;
            npcUsable.enabled = false;
            npcAnim.SetBool("PlayingGuitar", true);

        }
    }
}
