using System;
using TMPro;
using UnityEngine;

public class Fail : MonoBehaviour
{
    public TextMeshProUGUI failMessage;
    public TextMeshProUGUI failMessageFG;
    public GameObject restartButton;
    public static bool inFail;

    private void Start()
    {
        inFail = false;
        restartButton.SetActive(true);
    }

    private void Update()
    {
        if (Timer.secondsElapsed == GlobalRefLevel.levelProperties.stageCompleteTime && !inFail)
        {
            if (Lives.liveRemaining == 1)
            {
                failMessage.text = "You ran out of lives!";
                restartButton.SetActive(false);
            }

            inFail = true;
            GlobalMethods.SidePanelsMoveIn();
            ExpandFail();
        }
        
        if(inFail && Fade.fade_color.a < .4f)
        {
            Fade.FadeIn();
        }
    }

    public void ExpandFail()
    {
        iTween.ScaleTo(gameObject,
            iTween.Hash(
                "scale", new Vector3(1.7f, 1.7f, 1f),
                "time", .75f));

        iTween.RotateTo(gameObject,
            iTween.Hash(
                "rotation", new Vector3(0f, 0f, 0f),
                "time", .75f,
                "easetype", "easeoutback"));
    }
}
