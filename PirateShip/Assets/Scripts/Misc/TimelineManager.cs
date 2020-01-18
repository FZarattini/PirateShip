using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{
    private bool fix = false;
    public PlayerMovement playerMov;
    public Animator playerAnimator;
    public RuntimeAnimatorController playerAnim;
    public PlayableDirector director;

    // Start is called before the first frame update
    void OnEnable()
    {
        playerAnim = playerAnimator.runtimeAnimatorController;
        playerAnimator.runtimeAnimatorController = null;
        playerMov.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(director.state != PlayState.Playing && !fix)
        {
            fix = true;
            playerMov.enabled = true;
            playerAnimator.runtimeAnimatorController = playerAnim;
        }
    }
}
