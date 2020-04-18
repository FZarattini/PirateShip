using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class Extraversion : MonoBehaviour
{
    /* Relacionado a interação entre Player e NPCs - Frequência e rapidez */


    #region Singleton
    private static Extraversion _instance;
    private static Extraversion Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject op = new GameObject("Extraversion");
                op.AddComponent<Extraversion>();
            }
            return _instance;
        }
    }
    #endregion

    public delegate void OnNPCInteracted();
    public static event OnNPCInteracted onNPC;

    public PlayerController player;

    public int maxNPCs;
    [SerializeField] int interactedNPCs;

    public float assignedValue;
    public float assignedReverseValue;

    private void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        onNPC += IncrementNPC;
    }


    public static void RegisterNPC()
    {
        onNPC();
    }

    void IncrementNPC()
    {
        interactedNPCs += 1;
    }

    public void ProcessInteractedNPCs()
    {
        GameController.CheckInteractions();

    }

    public void AssignExtraversion()
    {
        //Recupera a pontuação e a pontuação reversa
        assignedValue = DialogueLua.GetVariable("ExtraversionValue").AsFloat;
        assignedReverseValue = 6 - DialogueLua.GetVariable("ExtraversionReversedValue").AsFloat;

        //Média entre a pontuação e a pontuação reversa
        float mean = (assignedValue + assignedReverseValue) / 2.0f;
        //Normaliza o valor
        float normalizedValue = (mean - 1) / 4.0f;

        player.personality.personality[2] = normalizedValue;
    }
}
