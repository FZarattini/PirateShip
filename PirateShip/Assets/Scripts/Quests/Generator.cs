using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class Generator : Quest
{

    public GameObject generator;
    public Sprite generatorOnSprite;
    public GameObject[] lights;
   
    // Update is called once per frame
    public override void Update()
    {
        if(DialogueLua.GetVariable("GeneratorQuestAccepted").AsBool == true)
        {
            accepted = true;
        }
        base.Update();
    }

    public void ActivateGenerator()
    {
        if (accepted)
        {
            generator.GetComponent<SpriteRenderer>().sprite = generatorOnSprite;

            foreach (GameObject l in lights)
            {
                l.SetActive(true);
            }

            completed = true;
        }
    }
}
