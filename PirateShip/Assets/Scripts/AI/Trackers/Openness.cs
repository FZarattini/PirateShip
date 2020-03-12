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

    public delegate void OnNPCInteracted();
    public static event OnNPCInteracted onNPC;

    public PlayerController player;
    public Inventory inventory;

    public int maxAreas;
    [SerializeField]int visitedAreas = 0;

    public int maxNPCs;
    [SerializeField]int interactedNPCs;

    private void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        onVisit += IncrementArea;
        onNPC += IncrementNPC;
    }

    // Update is called once per frame
    void Update()
    {
        
    } 

    public static void RegisterVisit()
    {
        onVisit();
    }

    public static void RegisterNPC()
    {
        onNPC();
    }

    void IncrementArea()
    {
        visitedAreas += 1;
    }

    void IncrementNPC()
    {
        interactedNPCs += 1;
    }

    public void ProcessVisitedAreas()
    {

    }

    public void ProcessInteractedNPCs()
    {

    }
}
