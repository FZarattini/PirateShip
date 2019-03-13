﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool open = false;
    public string animationName;
    public Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenDoors()
    {

        anim.Play(animationName);
    }
}