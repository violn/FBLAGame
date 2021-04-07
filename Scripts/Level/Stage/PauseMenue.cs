using UnityEngine;

public class PauseMenue : MonoBehaviour
{
    public KeyCode pauseKey;
    public static bool paused;

    private void Start()
    {
        paused = false;
    }

    private void Update()
    {
        if (!FinishLevel.inResults && !paused && Input.GetKeyDown(pauseKey))
        {
            gameObject.SetActive(true);
            paused = true;
            GlobalRef.globalMethod.SidePanelsMoveIn();
            iTween.MoveTo(gameObject,
                iTween.Hash(
                    "position", new Vector3(0f, 0f, 0f) + GlobalRef.globalVariable.localPosition,
                    "time", .75f,
                    "easetype", "easeoutback"));
        }
        else if (paused && Input.GetKeyDown(pauseKey))
        {
            GlobalRef.globalMethod.SidePanelsMoveOut();
            iTween.MoveTo(gameObject,
                iTween.Hash(
                    "position", new Vector3(-1920f, 0f, 0f) + GlobalRef.globalVariable.localPosition,
                    "time", .75f,
                    "easetype", "easeoutback",
                    "oncompletetarget", gameObject,
                    "oncomplete", "Unpaused"));
        }

        if (FinishLevel.inResults && gameObject.transform.position == new Vector3(0f, 0f, 0f) + GlobalRef.globalVariable.localPosition)
        {
            gameObject.SetActive(false);
            paused = false;
            gameObject.transform.position = new Vector3(1920f, 0f, 0f) + GlobalRef.globalVariable.localPosition;
        }
    }

    public void Unpaused()
    {
        paused = false;
        gameObject.transform.position = new Vector3(1920f, 0f, 0f) + GlobalRef.globalVariable.localPosition;
    }

    public void Resume()
    {
        GlobalRef.globalMethod.SidePanelsMoveOut();
        iTween.MoveTo(gameObject,
            iTween.Hash(
                "position", new Vector3(-1920f, 0f, 0f) + GlobalRef.globalVariable.localPosition,
                "time", .75f,
                "easetype", "easeoutback",
                "oncompletetarget", gameObject,
                "oncomplete", "Unpaused"));
    }
}