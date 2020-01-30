using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PixelCrushers.DialogueSystem.SequencerCommands
{
    public class SequencerCommandPlayer : SequencerCommand
    {

        bool playerState;
        GameObject player;

        // Start is called before the first frame update
        void Start()
        {
            playerState = GetParameterAsBool(0);
            player = GameObject.FindGameObjectWithTag("Player");
        }

        // Update is called once per frame
        void Update()
        {
            if (playerState == false)
            {
                player.GetComponent<PlayerMovement>().enabled = false;
            }
            else
            {
                player.GetComponent<PlayerMovement>().enabled = true;
                Stop();
            }
        }
    }
}
