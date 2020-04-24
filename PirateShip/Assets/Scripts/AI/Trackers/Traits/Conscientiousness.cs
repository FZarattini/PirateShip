using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class Conscientiousness : MonoBehaviour
{
    #region Singleton
    private static Conscientiousness _instance;
    private static Conscientiousness Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject op = new GameObject("Conscientiousness");
                op.AddComponent<Conscientiousness>();
            }
            return _instance;
        }
    }
    #endregion

    public delegate void OnQuestCompleted();
    public static event OnQuestCompleted onCompleteQuest;

    public PlayerController player;

    public int maxQuests;
    [SerializeField] int completedQuests = 0;

    public float assignedValue;
    public float assignedReverseValue;


    // Start is called before the first frame update
    void Start()
    {
        onCompleteQuest += IncrementCompletedQuests;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void RegisterCompletedQuest()
    {
        onCompleteQuest();
    }

    void IncrementCompletedQuests()
    {
        completedQuests += 1;
    }

    public float AssignConscientiousness()
    {
        float questCompletionRate = completedQuests / maxQuests;

        if(questCompletionRate < 0.2)
        {
            assignedValue = 1;
        }else if(questCompletionRate > 0.2 && questCompletionRate < 0.4)
        {
            assignedValue = 2;
        }else if(questCompletionRate > 0.4 && questCompletionRate < 0.6)
        {
            assignedValue = 3;
        }
        else if (questCompletionRate > 0.6 && questCompletionRate < 0.8)
        {
            assignedValue = 4;
        }
        else
        {
            assignedValue = 5;
        }

        //Recupera a pontuação e a pontuação reversa
        //assignedValue = DialogueLua.GetVariable("ConscientiousnessValue").AsFloat;
        assignedReverseValue = 6 - DialogueLua.GetVariable("ConscientiousnessReversedValue").AsFloat;

        //Média entre a pontuação e a pontuação reversa
        float mean = (assignedValue + assignedReverseValue) / 2.0f;
        //Normaliza o valor
        float normalizedValue = (mean - 1) / 4.0f;

        return normalizedValue;
        //player.personality.personality[1] = normalizedValue;
    }

}
