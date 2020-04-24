using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public bool accepted = false;
    public bool completed = false;
    public bool rejected = false;
    public bool failed = false;
    public NPCController giver;

    public bool isMainQuest;

    // Start is called before the first frame update
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (completed)
        {
            giver.OnQuestCompleted();
        }else if (failed)
        {
            giver.OnQuestFailed();
        }else if (accepted)
        {
            giver.OnQuestAccepted();
        }
    }
}
