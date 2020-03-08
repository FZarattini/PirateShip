using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Openness.onVisit += DeleteArea;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DeleteArea()
    {
        Object.Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Openness.RegisterVisit();
        }
    }
}
