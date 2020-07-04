using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

/// <summary>
/// Classe Trait - Representa os traços da personalidade
/// </summary>
public class Trait : MonoBehaviour
{
    protected float assignedValue;
    protected float assignedReverseValue;

    protected virtual void Awake()
    {
        
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    /// <summary>
    /// Calculates the Personality Trait received as parameter
    /// </summary>
    /// <param name="trait"></param>
    /// <param name="reversedTrait"></param>
    /// <returns> The normalized Score of the Personality Trait in the Big 5 Model </returns>
    public virtual float CalculateTrait(string trait, string reversedTrait)
    {
        // Retrieves the reversed score of the trait
        assignedReverseValue = 6 - DialogueLua.GetVariable(reversedTrait).AsFloat;

        // Calculates the mean of the score and the reversed score
        float mean = (assignedValue + assignedReverseValue) / 2.0f;

        //  Normalizes the score
        float normalizedValue = (mean - 1) / 4.0f;

        // Returns the normalized score
        return normalizedValue;
    }
}
