using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class MainQuest_WitchPrank : Quest
{
    public List<GameObject> cans;
    private bool allCansChecked = false;

    public override void Update()
    {

        // Caso jogador concorde em checar todas as latas de lixo
        if(DialogueLua.GetVariable("PrankQuestOnHold").AsBool == true)
        {
            accepted = true;

            foreach (GameObject c in cans)
            {
                c.GetComponent<BoxCollider2D>().enabled = true;
            }

            //Checa todas as latas
            foreach (GameObject c in cans)
            {
                //Se uma não foi checada, break
                if (c.GetComponent<Interactable>().GetHasInteracted() == false)
                {
                    allCansChecked = false;
                    break;
                }

                //Todas as latas foram checadas
                allCansChecked = true;           
            }

            if (allCansChecked)
            {
                //Avisa que todas as latas foram checadas
                DialogueLua.SetVariable("PrankCansChecked", true);

                //Não precisa mais entrar neste if
                DialogueLua.SetVariable("PrankQuestOnHold", false);

                foreach (GameObject c in cans)
                {
                    c.GetComponent<BoxCollider2D>().enabled = false;
                }
            }

        }

        //Caso o jogador concorde em checar apenas uma lata de lixo
        if (DialogueLua.GetVariable("PrankQuestOnHoldPartial").AsBool == true)
        {
            foreach (GameObject c in cans)
            {
                c.GetComponent<BoxCollider2D>().enabled = true;
            }

            accepted = true;
            foreach (GameObject c in cans)
            {
                //Se uma lata foi checada, break
                if (c.GetComponent<Interactable>().GetHasInteracted() == true)
                {
                    //Avisa que uma lata foi checada
                    DialogueLua.SetVariable("PrankCansChecked", true);
                    DialogueLua.SetVariable("PrankQuestOnHoldPartial", false);
                    Debug.Log("LATAS CHECADAS");

                    c.GetComponent<BoxCollider2D>().enabled = false;

                    break;
                }
            }
        }

        if (DialogueLua.GetVariable("PrankQuestCompleted").AsBool == true || DialogueLua.GetVariable("PrankQuestRejected").AsBool == true)
        {
            completed = true;
        }

        base.Update();
    }
}
