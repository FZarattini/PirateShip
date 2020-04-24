using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonalityDisplay : MonoBehaviour
{

    public PlayerController player;
    public Canvas displayCanvas;
    public Text text;
    public bool canDisplay = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canDisplay == true)
        {
            text.text = "O: " + player.personality.personality[0] + " C: " + player.personality.personality[1] + " E: " + player.personality.personality[2] + " A: " + player.personality.personality[3] + " N: " + player.personality.personality[4]; 

        }
    }
}
