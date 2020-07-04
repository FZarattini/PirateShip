using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    private GameObject parent;
    private bool deactivateCanvas;

    public void Fade(GameObject toFade, bool deactivateCanvas)
    {
        this.deactivateCanvas = deactivateCanvas;
        parent = toFade.transform.root.gameObject;

        Image toFadeImage = toFade.GetComponent<Image>();
        if (toFade.GetComponent<Image>().color.a == 1)
        {
            StartCoroutine(FadeOutImage(toFadeImage));
        }
        else
        {
            StartCoroutine(FadeInImage(toFadeImage));
        }
    }

    IEnumerator FadeInImage(Image toFade)
    {
        if (deactivateCanvas)
        {
            parent.SetActive(true);
        }
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            toFade.color = new Color(toFade.color.r, toFade.color.g, toFade.color.b, i);
            yield return null;
        }
    }

    IEnumerator FadeOutImage(Image toFade)
    {
        Debug.Log("ENTROU FADEOUT");
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            toFade.color = new Color(toFade.color.r, toFade.color.g, toFade.color.b, i);
            yield return null;
        }
        if (deactivateCanvas)
        {
            Debug.Log("DESATIVOU CANVAS");
            parent.SetActive(false);
        }
    }
}
