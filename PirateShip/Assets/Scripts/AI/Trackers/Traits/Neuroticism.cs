using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class Neuroticism : Trait
{
       
    #region Singleton
    private static Neuroticism _instance;
    private static Neuroticism Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject op = new GameObject("Neuroticism");
                op.AddComponent<Neuroticism>();
            }
            return _instance;
        }
    }
    #endregion

    public PlayerController player;

    // Awake é chamada assim que todos os objetos são inicializados
    protected override void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        
    }

    /// <summary>
    /// Calculates the Neuroticism Personality Trait in the Big 5 Model
    /// </summary>
    /// <param name="trait"></param>
    /// <param name="reversedTrait"></param>
    /// <returns> The normalized score for the Neuroticism personality trait </returns>
    public override float CalculateTrait(string trait, string reversedTrait)
    {
        assignedValue = DialogueLua.GetVariable("NeuroticismValue").AsFloat;

        return base.CalculateTrait(trait, reversedTrait);
    }
}
