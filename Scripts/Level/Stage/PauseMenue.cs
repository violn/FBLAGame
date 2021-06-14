using UnityEngine;

public class PauseMenue : MonoBehaviour
{
    public KeyCode pauseKey;
    private static bool paused;

    private void Start()
    {
        paused = false;
    }

    private void Update()
    {
        if (!FinishLevel.inResults && !paused && Input.GetKeyDown(pauseKey))
        {
            PlayerProps.still = false;
            gameObject.SetActive(true);
            paused = true;
            GlobalMethods.SidePanelsMoveIn();
            iTween.MoveTo(gameObject,
                iTween.Hash(
                    "position", new Vector3(0f, 0f, 0f) + GlobalVariables.localPosition,
                    "time", .75f,
                    "easetype", "easeoutback"));
        }
        else if (paused && Input.GetKeyDown(pauseKey))
        {
            GlobalMethods.SidePanelsMoveOut();
            iTween.MoveTo(gameObject,
                iTween.Hash(
                    "position", new Vector3(-1920f, 0f, 0f) + GlobalVariables.localPosition,
                    "time", .75f,
                    "easetype", "easeoutback",
                    "oncompletetarget", gameObject,
                    "oncomplete", "Unpaused"));
        }

        if (FinishLevel.inResults && gameObject.transform.position == new Vector3(0f, 0f, 0f) + GlobalVariables.localPosition)
        {
            gameObject.SetActive(false);
            paused = false;
            gameObject.transform.position = new Vector3(1920f, 0f, 0f) + GlobalVariables.localPosition;
        }
    }

    public void Unpaused()
    {
        paused = false;
        gameObject.transform.position = new Vector3(1920f, 0f, 0f) + GlobalVariables.localPosition;
    }

    public void Resume()
    {
        GlobalMethods.SidePanelsMoveOut();
        iTween.MoveTo(gameObject,
            iTween.Hash(
                "position", new Vector3(-1920f, 0f, 0f) + GlobalVariables.localPosition,
                "time", .75f,
                "easetype", "easeoutback",
                "oncompletetarget", gameObject,
                "oncomplete", "Unpaused"));
    }
}
