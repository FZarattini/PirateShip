using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The 5 possible levels of empathy
/// </summary>
public enum EmpathyEnum
{
    sympathetic,
    comprehensive,
    neutral,
    incomprehensive,
    unsympathetic
};

/// <summary>
/// Represents the Empathy between the player and the NPC
/// </summary>
public class Empathy : MonoBehaviour
{

    public EmpathyEnum empathy;
    float sympThreshold = 0.2f;
    float compThreshold = 0.4f;
    float neutralThreshold = 0.6f;
    float incompThreshold = 0.8f;
    float unsympThreshold = 1f;

    /// <summary>
    /// Calculates the base empathy considering every personality trait and its importance
    /// </summary>
    /// <param name="playerPersonality"></param>
    /// <param name="npcPersonality"></param>
    public void CalculateBaseEmpathy(float agreeablenessWeight, float conscientiousnessWeight, Personality playerPersonality, Personality npcPersonality)
    {
        Debug.Log("--------------------------------------------------------------------");
        float[] npcScore = npcPersonality.personality;
        float[] playerScore = playerPersonality.personality;
        float playerMean = 0;
        float npcMean = 0;
        float personalityDiff;

        playerMean = (playerScore[0] + playerScore[1] * conscientiousnessWeight + playerScore[2] + playerScore[3] * agreeablenessWeight + playerScore[4]) / 
            (3.0f + conscientiousnessWeight + agreeablenessWeight);
        npcMean = (npcScore[0] + npcScore[1] * conscientiousnessWeight + npcScore[2] + npcScore[3] * agreeablenessWeight + npcScore[4]) / 
            (3.0f + conscientiousnessWeight + agreeablenessWeight);

        personalityDiff = Mathf.Abs(playerMean - npcMean);
        Debug.Log("PersonalityPlayer: " + playerMean + " PersonalityNPC: " + npcMean + " PersonalityDiff = " + personalityDiff);

        if(personalityDiff <= sympThreshold)
        {
            empathy = EmpathyEnum.sympathetic;
        }else if(personalityDiff <= compThreshold)
        {
            empathy = EmpathyEnum.comprehensive;
        }else if (personalityDiff <= neutralThreshold)
        {
            empathy = EmpathyEnum.neutral;
        }else if (personalityDiff <= incompThreshold)
        {
            empathy = EmpathyEnum.incomprehensive;
        }else if(personalityDiff <= unsympThreshold)
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

