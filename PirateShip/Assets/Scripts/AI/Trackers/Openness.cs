using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Openness : MonoBehaviour
{

    #region Singleton
    private static Openness _instance;
    private static Openness Instance
    {
        get
        {
            if(_instance == null)
            {
                GameObject op = new GameObject("Openness");
                op.AddComponent<Openness>();
            }
            return _instance;
        }
    }
    #endregion

    public delegate void OnAreaVisited();
    public static event OnAreaVisited onVisit;

    public PlayerController player;
    public Inventory inventory;
    public GameObject mineCart;
    public GameObject lever;

    public int maxAreas;
    int visitedAreas = 0;

    private void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        onVisit += IncrementArea;

    }

    // Update is called once per frame
    void Update()
    {
        
    } 

    public static void RegisterVisit()
    {
        onVisit();
    }

    void IncrementArea()
    {
        visitedAreas += 1;
    }

    public void ProcessVisitedAreas()
    {

    }

    #region Puzzle
    public void MoveCart()
    {
        mineCart.transform.Translate(new Vector3(3f, 0f, 0f));
        lever.transform.localScale = new Vector3(lever.transform.localScale.x * (-1), lever.transform.localScale.y, lever.transform.localScale.z);
    }
    #endregion
}
