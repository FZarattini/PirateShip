using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSign : MonoBehaviour
{
    public Sprite questAvailableSprite;
    public Sprite questAcceptedSprite;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.sprite = questAvailableSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AcceptQuest()
    {
        sr.sprite = questAcceptedSprite;
    }

    public void CompleteQuest()
    {
        Destroy(this);
    }

    public void FailQuest()
    {
        Destroy(this);
    }
}
