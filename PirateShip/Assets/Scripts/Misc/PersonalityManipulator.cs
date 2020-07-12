using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonalityManipulator : MonoBehaviour
{
    private GameController gc;

    private void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }

    public void ConscientiousnessPlus(float value)
    {
        gc.OnIncreaseConscientiousness(value);
    }

    public void ConscientiousnessMinus(float value)
    {
        gc.OnDecreaseConscientiousness(value);
    }

    public void AgreeablenessPlus(float value)
    {
        gc.OnIncreaseAgreeableness(value);
    }

    public void AgreeablenessMinus(float value)
    {
        gc.OnDecreaseAgreeableness(value);
    }

    public void TogglePersonality()
    {
        gc.TogglePersonalityDisplay();
    }
}
