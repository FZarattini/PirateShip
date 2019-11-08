using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EmpathyEnum
{
    sympathetic,
    comprehensive,
    neutral,
    incomprehensive,
    hateful
};

public class Empathy: MonoBehaviour
{

    public EmpathyEnum empathy;
    private Personality npcPersonality;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CalculateBaseEmpathy(Personality npcPersonality, Personality playerPersonality)
    {
        //Relações entre personalidades retornando uma empatia do enumerador
        return;
    }

}
