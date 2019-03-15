using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraSway : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;
    bool goUp;
    public float upSwayLimit;
    public float downSwayLimit;
    public float swayFactor;

    private void Start()
    {
        goUp = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (goUp)
        {
            upSway();
        }
        else
        {
            downSway();
        }

        /*if (vcam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.y >= 0.6)
        {
            Debug.Log("deveria descer!");
            downSway();
        }

        if(vcam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.y <= 0.6)
        {
            Debug.Log("Deveria subir!");
            upSway();
        }*/

    }

    private void upSway()
    {
        vcam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.y += 0.1f * Time.deltaTime * swayFactor;
        if(vcam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.y >= upSwayLimit)
        {
            goUp = false;
        }
    }

    private void downSway()
    {
        vcam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.y -= 0.1f * Time.deltaTime * swayFactor;
        if(vcam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.y <= downSwayLimit)
        {
            goUp = true;
        }
    }
}
