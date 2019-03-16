using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{

    public GameObject target;
    private Vector3 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = new Vector3(target.transform.position.x, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LookAt(GameObject target)
    {
        if(target.transform.position.x - transform.position.x > 0)
        {
            transform.right = new Vector3(targetPos.x - transform.position.x, 0f, 0f);
        }
        else
        {
            transform.right = new Vector3(transform.position.x - targetPos.x, 0f, 0f);
        }
    }

}
