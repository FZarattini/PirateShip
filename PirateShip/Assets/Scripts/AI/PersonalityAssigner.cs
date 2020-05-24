using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonalityAssigner : MonoBehaviour
{
    public GameController gc;
    public PersonalityDisplay pd;

    public Openness openness;
    public Conscientiousness conscientiousness;
    public Extraversion extraversion;
    public Agreeableness agreeableness;
    public Neuroticism neuroticism;

    public List<Quest> auxQuestList;

    private int mainQuestsCompleted = 0;
    private int mainQuestsTotal = 0;

    private bool canGenerate = false;
    private bool hasGenerated = false;

    private float[] generatedPersonality;

    private void Start()
    {
        //gc.questList.CopyTo(auxQuestList);
        auxQuestList = new List<Quest>(gc.questList);

        foreach(Quest q in gc.questList)
        {
            if (q.isMainQuest)
            {
                mainQuestsTotal++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Total " + mainQuestsTotal);
        Debug.Log("Completed " + mainQuestsCompleted);
      
    }

    public void GeneratePersonality()
    {
        generatedPersonality[0] = openness.AssignOpenness();
        generatedPersonality[1] = conscientiousness.AssignConscientiousness();
        generatedPersonality[2] = extraversion.AssignExtraversion();
        generatedPersonality[3] = agreeableness.AssignAgreeableness();
        generatedPersonality[4] = neuroticism.AssignNeuroticism();
    }

    public void CheckGeneration()
    {
        foreach (Quest q in auxQuestList)
        {
            if (q.isMainQuest && q.completed)
            {
                mainQuestsCompleted += 1;
            }

            if (mainQuestsCompleted == mainQuestsTotal)
            {
                Debug.Log(mainQuestsTotal);
                GeneratePersonality();
                pd.canDisplay = true;
            }

        }
    }
}
