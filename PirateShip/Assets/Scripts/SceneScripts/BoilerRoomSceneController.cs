using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using UnityEngine.Playables;

public class BoilerRoomSceneController : MonoBehaviour
{
    public PlayerMovement pm;
    private GameController gc;

    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        Debug.Log("VAI INICIALIZAR NPCS!");
        gc.InitializeNPCs();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
