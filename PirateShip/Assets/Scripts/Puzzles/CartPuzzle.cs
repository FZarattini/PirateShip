using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartPuzzle : MonoBehaviour
{

    public GameObject mineCart;
    public GameObject lever;
    public float endPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveCart(float endPosition)
    {
        lever.transform.localScale = new Vector3(lever.transform.localScale.x * (-1), lever.transform.localScale.y, lever.transform.localScale.z);
        mineCart.transform.Translate(new Vector3(endPosition, 0f, 0f));
    }
}
