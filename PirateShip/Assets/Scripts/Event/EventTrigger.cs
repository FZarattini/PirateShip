using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventTrigger : MonoBehaviour
{
    GameController game;

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
        game = FindObjectOfType<GameController>();
        //_singleTrigger = singleTrigger;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (singleTrigger && _hasTriggered)
                return;

            _hasTriggered = true;
            StartCoroutine(RunEventSequence());
        }
    }

    /*private void OnTriggerStay2D(Collider2D collision)
    {
        
    }*/

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