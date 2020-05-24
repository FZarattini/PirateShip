using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EmpathyEnum
{
    sympathetic,
    comprehensive,
    neutral,
    incomprehensive,
    unsympathetic
};

public class Empathy : MonoBehaviour
{

    public EmpathyEnum empathy;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Relações entre personalidades retornando uma empatia do enumerador
    public void CalculateBaseEmpathy(Personality playerPersonality, Personality npcPersonality)
    {
        Debug.Log("--------------------------------------------------------------------");
        float[] npcScore = npcPersonality.personality;
        float[] playerScore = playerPersonality.personality;
        float playerMean = 0;
        float npcMean = 0;
        float personalityDiff;

        playerMean = (playerScore[0] + playerScore[1] * 2.0f + playerScore[2] + playerScore[3] * 3.0f + playerScore[4]) / 8.0f;
        npcMean = (npcScore[0] + npcScore[1] * 2.0f + npcScore[2] + npcScore[3] * 3.0f + npcScore[4]) / 8.0f;

        personalityDiff = Mathf.Abs(playerMean - npcMean);
        Debug.Log("PersonalityPlayer: " + playerMean + " PersonalityNPC: " + npcMean + " PersonalityDiff = " + personalityDiff);

        if(personalityDiff <= 0.2f)
        {
            empathy = EmpathyEnum.sympathetic;
        }else if(personalityDiff <= 0.4f)
        {
            empathy = EmpathyEnum.comprehensive;
        }else if (personalityDiff <= 0.6f)
        {
            empathy = EmpathyEnum.neutral;
        }else if (personalityDiff <= 0.8f)
        {
            empathy = EmpathyEnum.incomprehensive;
        }else if(personalityDiff <= 1.0f)
        {
            empathy = EmpathyEnum.unsympathetic;
        }

    }

    public void UpdateEmpathy(Personality npcPersonality, Personality playerPersonality)
    {
        float[] npcScore = npcPersonality.personality;
        float[] playerScore = playerPersonality.personality;
        float playerMean = 0;
        float npcMean = 0;
        float personalityDiff;

        playerMean = (playerPersonality.personality[1] + playerPersonality.personality[3]) / 2.0f;
        npcMean = (npcPersonality.personality[1] + npcPersonality.personality[3]) / 2.0f;

        personalityDiff = Mathf.Abs(playerMean - npcMean);
        if (personalityDiff <= 0.2f)
        {
            empathy = EmpathyEnum.sympathetic;
        }
        else if (personalityDiff <= 0.4f)
        {
            empathy = EmpathyEnum.comprehensive;
        }
        else if (personalityDiff <= 0.6f)
        {
            empathy = EmpathyEnum.neutral;
        }
        else if (personalityDiff <= 0.8f)
        {
            empathy = EmpathyEnum.incomprehensive;
        }
        else if (personalityDiff <= 1.0f)
        {
            empathy = EmpathyEnum.unsympathetic;
        }
    }
}

