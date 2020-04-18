using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

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
    
    public float finalValue;

    public float assignedValue;
    public float assignedReverseValue;

    private void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        onVisit += IncrementArea;
    }

    private void Update()
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

    public float ProcessVisitedAreas()
    {
        //Cálculo de porcentagem de áreas visitadas

        return (visitedAreas) / maxAreas;
    }

    public void AssignOpenness()
    {
        //Recupera a pontuação e a pontuação reversa
        assignedValue = DialogueLua.GetVariable("OpennessValue").AsFloat;
        assignedReverseValue = 6 - DialogueLua.GetVariable("OpennessReversedValue").AsFloat;
        
        //Média entre a pontuação e a pontuação reversa
        float mean = (assignedValue + assignedReverseValue) / 2.0f;
        //Normaliza o valor
        float normalizedValue = (mean - 1) / 4.0f;

        player.personality.personality[0] = normalizedValue;
    }
}
