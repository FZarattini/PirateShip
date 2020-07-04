using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MineSceneController : MonoBehaviour
{
    public bool sceneCompleted = false;
    public FadeController fc;
    public GameObject toFade;
    // Start is called before the first frame update
    void Start()
    {
        fc.Fade(toFade, true);
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneCompleted)
        {
            StartCoroutine("SceneTransition");
            //LevelManager.changeScene("Tracker2");
        }
    }

    IEnumerator SceneTransition()
    {
        fc.Fade(toFade, true);
        yield return new WaitForSeconds(1f);
        LevelManager.changeScene("Tracker2");
    }
}
