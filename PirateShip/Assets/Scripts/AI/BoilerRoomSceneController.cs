using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using UnityEngine.Playables;

public class BoilerRoomSceneController : SceneController
{
    //public PlayerMovement pm;
    //private GameController gc;

    public FadeController fc;
    public GameObject toFade;
    public Canvas fadeCanvas;

    // Start is called before the first frame update
    protected override void Start()
    {
        fc.Fade(toFade, true);
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        gc.InitializeNPCs();
        gc.InitializeNPCEmpathyDialogue();
    }

    // Update is called once per frame
    protected override void Update()
    {
        if(DialogueLua.GetVariable("TacticalFade").AsBool == true)
        {
            StartCoroutine("TacticalFade");
            DialogueLua.SetVariable("TacticalFade", false);
        }
    }

    IEnumerator TacticalFade()
    {
        fc.Fade(toFade, true);
        yield return new WaitForSeconds(4f);
        fc.Fade(toFade, true);
        yield return null;
    }
}
