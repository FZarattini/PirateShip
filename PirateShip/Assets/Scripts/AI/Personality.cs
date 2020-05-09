﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personality
{
    static int qtdPersonalidades = 5;

    public float Openness;
    public float Conscientiousness;
    public float Extraversion;
    public float Agreeableness;
    public float Neuroticism;

    public float[] personality = new float[qtdPersonalidades];

    /*public float[,] PositiveFactors = new float[5, 4] 
    {
        {-1, 1, 1, -1 },
        {0, 1, 0, 0 },
        {-1, 1, 1, 1 },
        {0, 0, 1, 1 },
        {1, -1, -1, 1 }
    };

    public float[,] NegativeFactors = new float[5, 4]
    {
        { -1, -1, -1, 1 },
        { 0, 0, 1, 1 },
        { 0, 0, 1, -1 },
        { 0, -1, 0, 0 },
        { 1, 1, 1, -1 }
    };*/

    public Personality(float[] personality)
    {
        Openness = personality[0];
        Conscientiousness = personality[1];
        Extraversion = personality[2];
        Agreeableness = personality[3];
        Neuroticism = personality[4];

        //Mathf.Clamp(Openness, 0f, 1f);
        //Mathf.Clamp(Conscientiousness, 0f, 1f);
        //Mathf.Clamp(Extraversion, 0f, 1f);
        //Mathf.Clamp(Agreeableness, 0f, 1f);
        //Mathf.Clamp(Neuroticism, 0f, 1f);

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
        PlayerPrefs.SetFloat("Openness", personality[0]);
        PlayerPrefs.SetFloat("Conscientiousness", personality[1]);
        PlayerPrefs.SetFloat("Extraversion", personality[2]);
        PlayerPrefs.SetFloat("Agreeableness", personality[3]);
        PlayerPrefs.SetFloat("Neuroticism", personality[4]);
    }

    public void LoadPersonality()
    {
        personality[0] = PlayerPrefs.GetFloat("Openness");
        personality[1] = PlayerPrefs.GetFloat("Conscientiousness");
        personality[2] = PlayerPrefs.GetFloat("Extraversion");
        personality[3] = PlayerPrefs.GetFloat("Agreeableness");
        personality[4] = PlayerPrefs.GetFloat("Neuroticism");
    }

}
