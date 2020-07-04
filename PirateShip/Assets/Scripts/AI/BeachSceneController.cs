using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class BeachSceneController : SceneController
{
    //private GameController gc;
    //private PersonalityDisplay pd;

    //private PlayerController player;
    public FadeController fc;
    public GameObject toFade;

    public Openness openness;
    public Conscientiousness conscientiousness;
    public Extraversion extraversion;
    public Agreeableness agreeableness;
    public Neuroticism neuroticism;

    public NPCController minerBoss;
    public Quest lastQuest;

    public GameObject cutsceneTimeline;
    private bool cutsceneStarted = false;

    private int mainQuestsTotal = 0;

    private bool canGenerate = false;
    private bool hasGenerated = false;

    private float[] generatedPersonality = new float[5];

    // Awake is called before the first frame of the scene
    private void Awake()
    {
        // Searches for the necessary Objects
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        pd = GameObject.FindGameObjectWithTag("PersonalityDisplay").GetComponent<PersonalityDisplay>();
    }

    // Start is called before the first frame of the scene and after Awake()
    protected override void Start()
    {
        fc.Fade(toFade, true);

        // Checks how many main quests there are in the scene
        foreach (Quest q in gc.questList)
        {
            if (q.isMainQuest)
            {
                mainQuestsTotal++;
            }
        }
        
        // Checks if the personality can be generated every second
        InvokeRepeating("CheckGeneration", 1f, 1f);
        
    }

    // Update is called once per frame
    protected override void Update()
    {
       
        // Checks for the scene transition
        if(DialogueLua.GetVariable("SceneTransition1").AsBool == true)
        {
            player.personality.SavePersonality();
            LevelManager.changeScene("BoilerRoom");
        }

        // Stops the check for personality generation
        if (hasGenerated)
        {
            player.hasPersonality = true;
            CancelInvoke();
        }

        // Starts cutscene
        if (lastQuest.completed && (cutsceneStarted == false))
        {
            cutsceneTimeline.SetActive(true);
            cutsceneStarted = true;
        }
    }

    //Checks the NPCs who the character has interacted with and registers them
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


    //<summary>
    // Generates the player personality based on the scores retrieved from the dialogues' answers
    //</summary>
    public void GeneratePersonality()
    {
        // Register the NPCs who the player has interacted with in the scene to use on the calculation of Extraversion
        CheckInteractions();
        
        // Calculates the score of each personality trait and stores it in a float array
        generatedPersonality[0] = openness.CalculateTrait("OpennessValue", "OpennessReversedValue");
        generatedPersonality[1] = conscientiousness.CalculateTrait("ConscientiousnessValue", "ConscientiousnessReversedValue");
        generatedPersonality[2] = extraversion.CalculateTrait("ExtraversionValue", "ExtraversionReversedValue");
        generatedPersonality[3] = agreeableness.CalculateTrait("AgreeablenessValue", "AgreeablenessReversedValue");
        generatedPersonality[4] = neuroticism.CalculateTrait("NeuroticismValue", "NeuroticismReversedValue");

        // Instantiate the player personality using the array calculated
        gc.player.personality = new Personality(generatedPersonality);

        // Updates flag booleans
        hasGenerated = true;
        pd.canDisplay = true;
    }

    //<summary>
    // Checks to verify if all the requirements to calculate the personality are met
    //</summary>
    public void CheckGeneration()
    {
        int mainQuestsCompleted = 0;


        // Checks if every obligatory quest on the scene has been completed to unlock the transition quest
        foreach (Quest q in gc.questList)
        {
            if (q.isMainQuest && q.completed)
            {
                mainQuestsCompleted += 1;
            }
        }

        // Unlocks the transition quest
        if (mainQuestsCompleted == mainQuestsTotal && lastQuest.completed == false)
        {
            DialogueLua.SetVariable("Tracker2MainQuestsCompleted", true);
            minerBoss.transform.GetChild(0).gameObject.SetActive(true);
        }

        // Generates the player personality if every trait score has been 
        if (DialogueLua.GetVariable("PersonalityValuesAssigned").AsBool == true)
        {
            GeneratePersonality();
        }
    }
}
