using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CutsceneCameraController : MonoBehaviour
{
    public CinemachineVirtualCamera cv;

    // Start is called before the first frame update
    void Start()
    {
        cv.Priority = 11;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
