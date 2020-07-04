using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a Personality in the Big 5 Model
/// </summary>
public class Personality
{
    // Quantity of trait in a given personality
    static int qtdPersonalidades = 5;

    // Traits
    private float Openness;
    private float Conscientiousness;
    private float Extraversion;
    private float Agreeableness;
    private float Neuroticism;

    // Score array that defines the personality
    public float[] personality = new float[qtdPersonalidades];

    /// <summary>
    /// Personality Constructor
    /// </summary>
    /// <param name="personality"></param>
    public Personality(float[] personality)
    {
        // Assign the scores to each trait
        Openness = personality[0];
        Conscientiousness = personality[1];
        Extraversion = personality[2];
        Agreeableness = personality[3];
        Neuroticism = personality[4];

        Initialize();
    }

    // Use this for initialization
    public void Initialize()
    {
        personality[0] = Openness;
        personality[1] = Conscientiousness;
        personality[2] = Extraversion;
        personality[3] = Agreeableness;
        personality[4] = Neuroticism;
    }

    /// <summary>
    /// Saves the Personality using PlayerPrefs
    /// </summary>
    public void SavePersonality()
    {
        // Saves every trait on the PlayerPrefs
        PlayerPrefs.SetFloat("Openness", this.personality[0]);
        PlayerPrefs.SetFloat("Conscientiousness", this.personality[1]);
        PlayerPrefs.SetFloat("Extraversion", this.personality[2]);
        PlayerPrefs.SetFloat("Agreeableness", this.personality[3]);
        PlayerPrefs.SetFloat("Neuroticism", this.personality[4]);
    }

    /// <summary>
    /// Loads the Personality from PlayerPrefs
    /// </summary>
    public void LoadPersonality()
    {
        // Loads every trait from the PlayerPrefs
        this.personality[0] = PlayerPrefs.GetFloat("Openness");
        this.personality[1] = PlayerPrefs.GetFloat("Conscientiousness");
        this.personality[2] = PlayerPrefs.GetFloat("Extraversion");
        this.personality[3] = PlayerPrefs.GetFloat("Agreeableness");
        this.personality[4] = PlayerPrefs.GetFloat("Neuroticism");

    }

    /// <summary>
    /// Updates the chosen trait with the parameter value
    /// </summary>
    /// <param name="index"></param>
    /// <param name="value"></param>
    public void UpdatePersonality(int index, float value)
    {
        // Changes the specific trait value
        this.personality[index] = value;
    }
}
