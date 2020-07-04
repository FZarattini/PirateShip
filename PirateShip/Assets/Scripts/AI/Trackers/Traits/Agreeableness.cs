using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class Agreeableness : Trait
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

    protected override void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        onAcceptQuest += IncrementActiveQuests;
    }

    public static void RegisterAcceptedQuest()
    {
        onAcceptQuest();
    }

    void IncrementActiveQuests()
    {
        activeQuests += 1;
    }

    /// <summary>
    /// Calculates the Agreeableness Personality Trait in the Big 5 Model
    /// </summary>
    /// <param name="trait"></param>
    /// <param name="reversedTrait"></param>
    /// <returns> The normalized score for the Agreeableness personality trait </returns>
    public override float CalculateTrait(string trait, string reversedTrait)
    {
        assignedValue = DialogueLua.GetVariable(trait).AsFloat;
        return base.CalculateTrait(trait, reversedTrait);
    }
}
