using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

/// <summary>
/// Represents the Openness personality trait in the Big 5 Model
/// </summary>
public class Openness : Trait
{

    //Singleton
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

    // RETIRAR
    public delegate void OnAreaVisited();
    public static event OnAreaVisited onVisit;

    public PlayerController player;
    public Inventory inventory;

    // RETIRAR
    public int maxAreas;

    [SerializeField]int visitedAreas = 0;

    // Awake é chamada assim que todos os objetos são inicializados
    protected override void Awake()
    {
        _instance = this;
    }


    /// <summary>
    /// Calculates the Openness Personality Trait in the Big 5 Model
    /// </summary>
    /// <param name="trait"></param>
    /// <param name="reversedTrait"></param>
    /// <returns> The normalized score for the Openness personality trait </returns>
    public override float CalculateTrait(string trait, string reversedTrait)
    {
        assignedValue = DialogueLua.GetVariable(trait).AsFloat;
        return base.CalculateTrait(trait, reversedTrait);
    }
}
