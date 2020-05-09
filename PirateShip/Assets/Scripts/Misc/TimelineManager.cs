using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using PixelCrushers.DialogueSystem;

public class TimelineManager : MonoBehaviour
{
    private bool fix = false;
    public PlayerMovement playerMov;
    public Animator playerAnimator;
    public PlayableDirector director;
    public GameObject nextTimeline;
    public string nextTimelineVarName;
    private RuntimeAnimatorController playerAnim;

    private void Start()
    {
        Debug.Log(gameObject.name + " Iniciando ");
        playerMov.enabled = false;
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        playerAnim = playerAnimator.runtimeAnimatorController;
    }

    // Update is called once per frame
    void Update()
    {
        if (director.state != PlayState.Playing && !fix && DialogueLua.GetVariable("DialogueInProgress").AsBool == false)
        {
            fix = true;
            playerMov.enabled = true;
            playerAnimator.runtimeAnimatorController = playerAnim;
        }

        if (nextTimelineVarName != "")
        {
            if (DialogueLua.GetVariable(nextTimelineVarName).AsBool == true)
            {               
                nextTimeline.SetActive(true);
                Destroy(this);
            }
        }
    }
}