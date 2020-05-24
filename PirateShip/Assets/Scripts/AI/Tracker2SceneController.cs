using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class Tracker2SceneController : MonoBehaviour
{
    private GameController gc;
    private PersonalityDisplay pd;

    private PlayerController player;

    public Openness openness;
    public Conscientiousness conscientiousness;
    public Extraversion extraversion;
    public Agreeableness agreeableness;
    public Neuroticism neuroticism;

    public NPCController minerBoss;
    public Quest lastQuest;

    public GameObject cutsceneTimeline;
    private bool cutsceneStarted = false;

    //private int mainQuestsCompleted = 0;
    private int mainQuestsTotal = 0;

    private bool canGenerate = false;
    private bool hasGenerated = false;

    private float[] generatedPersonality = new float[5];

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        pd = GameObject.FindGameObjectWithTag("PersonalityDisplay").GetComponent<PersonalityDisplay>();
    }

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
       
        if(DialogueLua.GetVariable("SceneTransition1").AsBool == true)
        {
            player.personality.SavePersonality();
            LevelManager.changeScene("BoilerRoom");
        }

        if (hasGenerated)
        {
            player.hasPersonality = true;
            CancelInvoke();
        }

        if (lastQuest.completed && (cutsceneStarted == false))
        {
            cutsceneTimeline.SetActive(true);
            cutsceneStarted = true;
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

    public void GeneratePersonality()
    {
        CheckInteractions();
        generatedPersonality[0] = openness.AssignOpenness();
        generatedPersonality[1] = conscientiousness.AssignConscientiousness();
        generatedPersonality[2] = extraversion.AssignExtraversion();
        generatedPersonality[3] = agreeableness.AssignAgreeableness();
        generatedPersonality[4] = neuroticism.AssignNeuroticism();

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

        if (mainQuestsCompleted == mainQuestsTotal && lastQuest.completed == false)
        {
            DialogueLua.SetVariable("Tracker2MainQuestsCompleted", true);
            minerBoss.transform.GetChild(0).gameObject.SetActive(true);
        }

        if (DialogueLua.GetVariable("PersonalityValuesAssigned").AsBool == true)
        {
            GeneratePersonality();
        }
    }
}
