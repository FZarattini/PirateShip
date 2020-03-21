using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public delegate void OnQuestCompleted();
    public static event OnQuestCompleted onCompleteQuest;

    public int maxQuests;
    [SerializeField] int activeQuests = 0;
    [SerializeField] int completedQuests = 0;

    private void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        onAcceptQuest += IncrementActiveQuests;
        onCompleteQuest += IncrementCompletedQuests;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void RegisterAcceptedQuest()
    {
        onAcceptQuest();
    }

    public static void RegisterCompletedQuest()
    {
        onCompleteQuest();
    }

    void IncrementActiveQuests()
    {
        activeQuests += 1;
    }

    void IncrementCompletedQuests()
    {
        completedQuests += 1;
    }
}
