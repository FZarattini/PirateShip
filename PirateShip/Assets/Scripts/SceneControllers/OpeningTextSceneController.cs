using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningTextSceneController : MonoBehaviour
{
    public FadeController fc;
    public GameObject[] texts;
    public GameObject[] toFade;
    public float textTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TextAnimation());
    }

    IEnumerator TextAnimation()
    {
        for(int i = 0; i < toFade.Length; i++)
        {
            texts[i].gameObject.SetActive(true);
            fc.Fade(toFade[i], false);
            yield return new WaitForSeconds(textTime);
            fc.Fade(toFade[i], false);
            yield return new WaitForSeconds(1f);
            texts[i].gameObject.SetActive(false);
        }
        LevelManager.changeScene("Tracker1");
        yield return null;
    }
}
