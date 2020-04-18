using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    //public string animationName;
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

    public void OpenDoors(string animationName)
    {
        Debug.Log("ABRINDO!!");
        anim.Play(animationName);      
        
    }

    public void CloseDoors(string animationName)
    {
        Debug.Log("FECHANDO!!");
        anim.Play(animationName);
    }
}
