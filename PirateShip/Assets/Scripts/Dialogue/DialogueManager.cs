using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    public Text nameText;
    public Text dialogueText;
    private bool talking = false;
    public GameObject dialogueCanvas;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        Debug.Log(talking);
    }

    private void Update()
    {

        if (talking && Input.GetKeyDown(KeyCode.E))
        {

            DisplayNextSentence();

        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueCanvas.SetActive(true);
        talking = true;

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        talking = false;
        dialogueCanvas.SetActive(false);
        Debug.Log("fim de conversa");
    }

}
