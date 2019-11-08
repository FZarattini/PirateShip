using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personality
{
    static int qtdEmocoes = 4;
    static int qtdPersonalidades = 5;

    public float Openness;
    public float Conscientiousness;
    public float Extraversion;
    public float Agreeableness;
    public float Neuroticism;

    public float[] personality = new float[qtdPersonalidades];

    public float[,] PositiveFactors = new float[5, 4] 
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
    };

    public Personality(float[] personality)
    {
        Openness = personality[0];
        Conscientiousness = personality[1];
        Extraversion = personality[2];
        Agreeableness = personality[3];
        Neuroticism = personality[4];

        Mathf.Clamp(Openness, 0f, 1f);
        Mathf.Clamp(Conscientiousness, 0f, 1f);
        Mathf.Clamp(Extraversion, 0f, 1f);
        Mathf.Clamp(Agreeableness, 0f, 1f);
        Mathf.Clamp(Neuroticism, 0f, 1f);

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
}
