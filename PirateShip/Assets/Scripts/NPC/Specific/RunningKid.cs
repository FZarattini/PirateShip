using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningKid : MonoBehaviour
{
    public Transform leftTransform;
    public Transform rightTransform;
    private Vector3 leftPos;
    private Vector3 rightPos;
    public float speed;

    private void Start()
    {
        leftPos = leftTransform.position;
        rightPos = rightTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x > 0)
        {
            if (transform.position.x <= leftPos.x)
            {
                transform.localScale = new Vector3((-1) * transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }

            transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
        }
        else
        {
            if (transform.position.x >= rightPos.x)
            {
                transform.localScale = new Vector3((-1) * transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }

            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }
    }
}
