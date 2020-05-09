using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraBounds : MonoBehaviour
{

    private CinemachineConfiner cc ;
    // Start is called before the first frame update
    private void Awake()
    {
        cc = gameObject.GetComponent<CinemachineConfiner>();
        cc.m_BoundingShape2D = GameObject.FindGameObjectWithTag("Bounds").GetComponent<PolygonCollider2D>();
    }
}
