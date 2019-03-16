using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraSway : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;
    bool goUp;
    bool right;
    public float upSwayLimit;
    public float downSwayLimit;
    public float swayFactor;

    private void Start()
    {
        goUp = true;
        right = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (goUp)
        {
            UpSway();
        }
        else
        {
            DownSway();
        }

        if (right)
        {
            RotateRight();
        }
        else
        {
            RotateLeft();
        }
    }

    private void UpSway()
    {
        vcam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.y += 0.1f * Time.deltaTime * swayFactor;
        if(vcam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.y >= upSwayLimit)
        {
            goUp = false;
        }
    }

    private void DownSway()
    {
        vcam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.y -= 0.1f * Time.deltaTime * swayFactor;
        if(vcam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.y <= downSwayLimit)
        {
            goUp = true;
        }
    }

    private void RotateRight()
    {
        transform.Rotate(0f, 0f, 0.001f);
        if(transform.rotation.z >= 0.006f)
        {
            right = false;
        }
    }

    private void RotateLeft()
    {
        transform.Rotate(0f,0f, -0.001f);
        if(transform.rotation.z <= -0.006f)
        {
            right = true;
        }
    }


}
