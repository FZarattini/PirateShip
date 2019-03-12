using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventTrigger : MonoBehaviour
{
    GameController game;
    private bool eventReady;
    public bool automatic;

    [System.Serializable]
    public class Event
    {
        public UnityEvent events;
        public float delay;
    }

    public List<Event> eventSequence;

    public bool singleTrigger = true;
    private bool _hasTriggered = false;

    // Use this for initialization
    void Awake()
    {
        //game = FindObjectOfType<GameController>();
        eventReady = false;
        //_singleTrigger = singleTrigger;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(automatic);
        if ( eventReady == true && Input.GetKeyDown(KeyCode.E))
        {
            if (singleTrigger && _hasTriggered)
                return;

            _hasTriggered = true;
            StartCoroutine(RunEventSequence());
        }
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (automatic == true)
        {
            if (singleTrigger && _hasTriggered)
                return;

            _hasTriggered = true;
            StartCoroutine(RunEventSequence());
        }
        else
        {
            eventReady = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        eventReady = false;
    }

    public void runEvent()
    {
        


    }
    private IEnumerator RunEventSequence()
    {
        foreach (Event eve in eventSequence)
        {
            yield return new WaitForSeconds(eve.delay);
            eve.events.Invoke();
        }

        yield break;
    }
}