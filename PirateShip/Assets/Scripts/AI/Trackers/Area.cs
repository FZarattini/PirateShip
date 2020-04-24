using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    void DeleteArea()
    {
        Object.Destroy(this.gameObject);
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GameController.CheckVisitedArea();
            DeleteArea();
        }
    }*/
}
