using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PersonalityDisplay : MonoBehaviour
{
    public PlayerController player;
    public Canvas displayCanvas;
    public Text text;
    public bool canDisplay = false;
    private bool newScene = false;
    public bool display = false;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.hasPersonality)
        {
            text.text = "O: " + player.personality.personality[0] + " C: " + player.personality.personality[1] + " E: " + player.personality.personality[2] + " A: " + player.personality.personality[3] + " N: " + player.personality.personality[4];
        }

        if (display)
        {
            text.enabled = true;
        }
        else
        {
            text.enabled = false;
        }
    }
}
