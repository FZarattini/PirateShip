using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personality
{
    static int qtdPersonalidades = 5;

    private float Openness;
    private float Conscientiousness;
    private float Extraversion;
    private float Agreeableness;
    private float Neuroticism;

    public float[] personality = new float[qtdPersonalidades];

    public Personality(float[] personality)
    {
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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SavePersonality()
    {
        Debug.Log("Salvando Personalidade!");
        PlayerPrefs.SetFloat("Openness", this.personality[0]);
        PlayerPrefs.SetFloat("Conscientiousness", this.personality[1]);
        PlayerPrefs.SetFloat("Extraversion", this.personality[2]);
        PlayerPrefs.SetFloat("Agreeableness", this.personality[3]);
        PlayerPrefs.SetFloat("Neuroticism", this.personality[4]);
    }

    public void LoadPersonality()
    {
        Debug.Log("Carregando Personalidade!");
        this.personality[0] = PlayerPrefs.GetFloat("Openness");
        this.personality[1] = PlayerPrefs.GetFloat("Conscientiousness");
        this.personality[2] = PlayerPrefs.GetFloat("Extraversion");
        this.personality[3] = PlayerPrefs.GetFloat("Agreeableness");
        this.personality[4] = PlayerPrefs.GetFloat("Neuroticism");

    }

    public void UpdatePersonality(int index, float value)
    {
        this.personality[index] = value;
    }
}
