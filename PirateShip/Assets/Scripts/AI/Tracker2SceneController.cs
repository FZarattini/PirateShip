using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker2SceneController : MonoBehaviour
{
    public GameController gc;
    public PersonalityDisplay pd;

    public Openness openness;
    public Conscientiousness conscientiousness;
    public Extraversion extraversion;
    public Agreeableness agreeableness;
    public Neuroticism neuroticism;

    //private int mainQuestsCompleted = 0;
    private int mainQuestsTotal = 0;

    private bool canGenerate = false;
    private bool hasGenerated = false;

    private float[] generatedPersonality = new float[5];

    private void Start()
    {
        foreach (Quest q in gc.questList)
        {
            if (q.isMainQuest)
            {
                mainQuestsTotal++;
            }
        }

        InvokeRepeating("CheckGeneration", 1f, 1f);
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Total " + mainQuestsTotal);

        if (hasGenerated)
        {
            CancelInvoke();
        }
    }

    public void CheckInteractions()
    {
        foreach (NPCController n in gc.npcList)
        {
            if (n.interacted == true)
            {                
                Extraversion.RegisterNPC();
            }
        }

    }

/*
    public  void CheckCompletedQuests()
    {
        foreach (Quest quest in gc.questList)
        {
            if (quest.completed == true)
            {
                Conscientiousness.RegisterCompletedQuest();
            }
        }
    }

    public  void CheckVisitedArea()
    { 
        Openness.RegisterVisit();
    }

    public  void CheckAcceptedQuests()
    {
        Agreeableness.RegisterAcceptedQuest();
    }
*/
    public void GeneratePersonality()
    {
        CheckInteractions();
        generatedPersonality[0] = openness.AssignOpenness();
        generatedPersonality[1] = conscientiousness.AssignConscientiousness();
        generatedPersonality[2] = extraversion.AssignExtraversion();
        generatedPersonality[3] = agreeableness.AssignAgreeableness();
        //generatedPersonality[4] = neuroticism.AssignNeuroticism();
        generatedPersonality[4] = 0f;

        gc.player.personality = new Personality(generatedPersonality);

        hasGenerated = true;
        pd.canDisplay = true;
    }

    public void CheckGeneration()
    {
        int mainQuestsCompleted = 0;
        foreach (Quest q in gc.questList)
        {
            if (q.isMainQuest && q.completed)
            {
                mainQuestsCompleted += 1;
            }
        }

        Debug.Log("Completed: " + mainQuestsCompleted);

        if (mainQuestsCompleted == mainQuestsTotal)
        {
            Debug.Log(mainQuestsTotal);
            GeneratePersonality();
        }
    }
}
