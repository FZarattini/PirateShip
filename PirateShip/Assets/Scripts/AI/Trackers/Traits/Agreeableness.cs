using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class Agreeableness : MonoBehaviour
{
    /* Relacionado ao altruísmo do jogador. Se está disposto a ajudar NPCs em perigo ou necessidade (Completude de quests secundárias)*/

    #region Singleton
    private static Agreeableness _instance;
    private static Agreeableness Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject op = new GameObject("Agreeableness");
                op.AddComponent<Agreeableness>();
            }
            return _instance;
        }
    }
    #endregion

    public delegate void OnQuestAccepted();
    public static event OnQuestAccepted onAcceptQuest;

    public PlayerController player;

    //public int maxQuests;
    [SerializeField] int activeQuests = 0;

    public float assignedValue;
    public float assignedReverseValue;

    private void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        onAcceptQuest += IncrementActiveQuests;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void RegisterAcceptedQuest()
    {
        onAcceptQuest();
    }

    void IncrementActiveQuests()
    {
        activeQuests += 1;
    }


    public float AssignAgreeableness()
    {
        //Recupera a pontuação e a pontuação reversa
        assignedValue = DialogueLua.GetVariable("AgreeablenessValue").AsFloat;
        assignedReverseValue = 6 - DialogueLua.GetVariable("AgreeablenessReversedValue").AsFloat;

        //Média entre a pontuação e a pontuação reversa
        float mean = (assignedValue + assignedReverseValue) / 2.0f;
        //Normaliza o valor
        float normalizedValue = (mean - 1) / 4.0f;

        return normalizedValue;
        //player.personality.personality[3] = normalizedValue;
    }
}
