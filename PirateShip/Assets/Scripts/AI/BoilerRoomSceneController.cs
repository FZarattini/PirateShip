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
        Debug.Log("VAI INICIALIZAR NPCS!");
        gc.InitializeNPCs();
    }

    // Update is called once per frame
    protected override void Update()
    {

    }
}
