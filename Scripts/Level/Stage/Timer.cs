//Sets and stores the game time in a level

using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI timerTextFG;
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
        if (!FinishLevel.inResults && !Fail.inFail && !PauseMenue.paused)
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

            if (seconds < 10)
            {
                timerText.text = minutes + ":0" + seconds;
                timerTextFG.text = minutes + ":0" + seconds;
            }
            else
            {
                timerText.text = minutes + ":" + seconds;
                timerTextFG.text = minutes + ":" + seconds;
            }
        }
    }
}