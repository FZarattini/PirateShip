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
        targetPos = new Vector3(0f, target.transform.position.y, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LookAt(GameObject target)
    {
        transform.right = targetPos - transform.position;
    }

}
