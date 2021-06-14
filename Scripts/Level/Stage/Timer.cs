using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerTextFG;
    public TextMeshProUGUI timerTextBG;
    public static int secondsElapsed;
    public static int frames;
    public static int seconds;
    public static int minutes;

    private void Start()
    {
        frames = 0;
        seconds = GlobalRefLevel.levelProperties.stageCompleteTime;
        secondsElapsed = 0;

        if (GlobalRefLevel.levelProperties.stageCompleteTime >= 60)
        {
            minutes = seconds / 60;
            seconds -= minutes * 60;
        }
        else minutes = 0;
    }

    private void FixedUpdate()
    {
        if (!FinishLevel.inResults && !Fail.inFail)
        {
            frames++;

            if (frames == 60)
            {
                seconds--;
                secondsElapsed++;
                frames = 0;
            }

            if (seconds == 0 && minutes != 0)
            {
                minutes--;
                seconds = 59;
            }

            timerTextFG.text = timerTextBG.text = seconds < 10 ? $"{minutes}:0{seconds}" : $"{minutes}:{seconds}";
        }
    }
}
