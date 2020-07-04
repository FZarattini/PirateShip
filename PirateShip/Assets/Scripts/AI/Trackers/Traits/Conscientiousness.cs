using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class Conscientiousness : Trait
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

    // Awake é chamada assim que todos os objetos são inicializados
    protected override void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        onCompleteQuest += IncrementCompletedQuests;
    }

    public static void RegisterCompletedQuest()
    {
        onCompleteQuest();
    }

    void IncrementCompletedQuests()
    {
        completedQuests += 1;
    }

    /// <summary>
    /// Calculates the Conscientiousness Personality Trait in the Big 5 Model
    /// </summary>
    /// <param name="trait"></param>
    /// <param name="reversedTrait"></param>
    /// <returns> The normalized score for the Conscientiousness personality trait </returns>
    public override float CalculateTrait(string trait, string reversedTrait)
    {
        // The Conscientiousness score is based on the amount of completed quests in relation to the total quests on the scene
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

        return base.CalculateTrait(trait, reversedTrait);
    }

}
