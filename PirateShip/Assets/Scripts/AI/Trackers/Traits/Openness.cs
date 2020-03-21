using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Openness : MonoBehaviour
{
    /* Relacionado a curiosidade do Player - Áreas exploradas e itens coletados*/

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

    public int maxAreas;
    [SerializeField]int visitedAreas = 0;

    private void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        onVisit += IncrementArea;

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
        //Cálculo de porcentagem de áreas visitadas
    }
}
