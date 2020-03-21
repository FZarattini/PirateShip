using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public Personality personality;
    public Empathy empathy;
    public Transform target;
    private Vector3 targetPos;
    public bool interacted = false;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        empathy = new Empathy();
        if(target)
        {
            targetPos = new Vector3(target.position.x, 0f, 0f);
        }
    }

    // Update is called once per frame
    protected virtual void Update()
    {

    }

    public void LookAt(Transform target)
    {

        if(target.position.x - transform.position.x > 0 && transform.localScale.x > 0)
        {
            //transform.right = new Vector3(targetPos.x - transform.position.x, 0f, 0f);          
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        else if(target.position.x - transform.position.x < 0 && transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            interacted = true;
            if (target)
                LookAt(target);
        }
    }

}
