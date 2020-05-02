using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class Neuroticism : MonoBehaviour
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

    public float assignedValue;
    public float assignedReverseValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public float AssignNeuroticism()
    {
        
        //Recupera a pontuação e a pontuação reversa
        assignedValue = DialogueLua.GetVariable("NeuroticismValue").AsFloat;
        assignedReverseValue = 6 - DialogueLua.GetVariable("NeuroticismReversedValue").AsFloat;

        //Média entre a pontuação e a pontuação reversa
        float mean = (assignedValue + assignedReverseValue) / 2.0f;
        //Normaliza o valor
        float normalizedValue = (mean - 1) / 4.0f;

        return normalizedValue;
        //player.personality.personality[4] = normalizedValue;
    }
}
