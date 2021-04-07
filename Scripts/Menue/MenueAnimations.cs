using UnityEngine;
using UnityEngine.SceneManagement;

public class MenueAnimations : MonoBehaviour
{
    public GameObject title;
    public GameObject play;
    public GameObject quit;
    public GameObject tutorial;
    public GameObject sidePanelRight;
    public GameObject sidePanelLeft;
    public static bool menueAnimating;
    public static bool doHorizontal;
    public static bool doDiagonal;
    public static bool doTutorial;
    public static bool doPlay;
    public static bool doQuickPlay;

    private void Start()
    {
        menueAnimating = false;
        doHorizontal = false;
        doDiagonal = true;
        doTutorial = false;
        doPlay = false;
        doQuickPlay = false;
        tutorial.transform.position = new Vector3(2000f, 0f) + GlobalRef.globalVariable.localPosition;
    }

    private void Update()
    {
        if (doDiagonal && !menueAnimating)
        {
            if (doTutorial)
            {
                MovePlanesDiagonal(1f);
                MoveOutTutorial();

                title.transform.position = new Vector3(2000f + GlobalRef.globalVariable.localPosition.x, title.transform.position.y);
                play.transform.position = new Vector3(2000f + GlobalRef.globalVariable.localPosition.x, play.transform.position.y);
                quit.transform.position = new Vector3(2000f + GlobalRef.globalVariable.localPosition.x, quit.transform.position.y);

                iTween.MoveTo(title,
                    iTween.Hash(
                        "position", new Vector3(0f + GlobalRef.globalVariable.localPosition.x, title.transform.position.y),
                        "time", 1f,
                        "easetype", "easeOutBack",
                        "delay", 1f));

                iTween.MoveTo(play,
                    iTween.Hash(
                        "position", new Vector3(0f + GlobalRef.globalVariable.localPosition.x, play.transform.position.y),
                        "time", 1f,
                        "delay", 1.25f,
                        "easetype", "easeOutBack"));

                iTween.MoveTo(quit,
                    iTween.Hash(
                        "position", new Vector3(0f + GlobalRef.globalVariable.localPosition.x, quit.transform.position.y),
                        "time", 1f,
                        "delay", 1.5f,
                        "easetype", "easeOutBack"));
            }
            else MovePlanesDiagonal();
        }
        else if (doHorizontal && !menueAnimating)
        {
            MovePlanesHorizontal();

            if (doTutorial)
            {
                iTween.MoveTo(title,
                    iTween.Hash(
                        "position", new Vector3(-2000f + GlobalRef.globalVariable.localPosition.x, title.transform.position.y),
                        "time", 1f,
                        "easetype", "easeInBack"));

                iTween.MoveTo(play,
                    iTween.Hash(
                        "position", new Vector3(-2000f + GlobalRef.globalVariable.localPosition.x, play.transform.position.y),
                        "time", 1f,
                        "delay", .25f,
                        "easetype", "easeInBack"));

                iTween.MoveTo(quit,
                    iTween.Hash(
                        "position", new Vector3(-2000f + GlobalRef.globalVariable.localPosition.x, quit.transform.position.y),
                        "time", 1f,
                        "delay", .50f,
                        "easetype", "easeInBack"));
            }

            if (doQuickPlay)
            {
                iTween.MoveTo(title,
                    iTween.Hash(
                        "position", new Vector3(-2000f + GlobalRef.globalVariable.localPosition.x, title.transform.position.y),
                        "time", 1f,
                        "easetype", "easeInBack"));

                iTween.MoveTo(play,
                    iTween.Hash(
                        "position", new Vector3(-2000f + GlobalRef.globalVariable.localPosition.x, play.transform.position.y),
                        "time", 1f,
                        "delay", .25f,
                        "easetype", "easeInBack"));

                iTween.MoveTo(quit,
                    iTween.Hash(
                        "position", new Vector3(-2000f + GlobalRef.globalVariable.localPosition.x, quit.transform.position.y),
                        "time", 1f,
                        "delay", .50f,
                        "easetype", "easeInBack",
                        "oncompletetarget", gameObject,
                        "oncomplete", "PlayGame"));
            }
        }
        else if (doPlay)
        {
            PlayGame();
        }
    }

    public void PlayGame()
    {
        iTween.MoveTo(sidePanelRight,
            iTween.Hash(
                "position", new Vector3(500f, -550f) + GlobalRef.globalVariable.localPosition,
                "time", 1f));

        iTween.MoveTo(sidePanelLeft,
            iTween.Hash(
                "position", new Vector3(-500f, -1000f) + GlobalRef.globalVariable.localPosition,
                "time", 1f,
                "oncompletetarget", gameObject,
                "oncomplete", "StartGame"));
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MovePlanesDiagonal()
    {
        menueAnimating = true;
        iTween.MoveTo(sidePanelRight,
            iTween.Hash(
                "position", new Vector3(145f, 670f) + GlobalRef.globalVariable.localPosition,
                "time", 1f));

        iTween.RotateTo(sidePanelRight,
            iTween.Hash(
                "rotation", new Vector3(0f, 0f, 119.36f),
                "time", 1f));

        iTween.MoveTo(sidePanelLeft,
            iTween.Hash(
                "position", new Vector3(-145f, -670f) + GlobalRef.globalVariable.localPosition,
                "time", 1f));

        iTween.RotateTo(sidePanelLeft,
            iTween.Hash(
                "rotation", new Vector3(0f, 0f, -60.64f),
                "time", 1f,
                "oncompletetarget", gameObject,
                "oncomplete", "Done"));
    }

    public void MovePlanesDiagonal(float delay)
    {
        menueAnimating = true;
        iTween.MoveTo(sidePanelRight,
            iTween.Hash(
                "position", new Vector3(145f, 670f) + GlobalRef.globalVariable.localPosition,
                "time", 1f,
                "delay", delay));

        iTween.RotateTo(sidePanelRight,
            iTween.Hash(
                "rotation", new Vector3(0f, 0f, 119.36f),
                "time", 1f,
                "delay", delay));

        iTween.MoveTo(sidePanelLeft,
            iTween.Hash(
                "position", new Vector3(-145f, -670f) + GlobalRef.globalVariable.localPosition,
                "time", 1f,
                "delay", delay));

        iTween.RotateTo(sidePanelLeft,
            iTween.Hash(
                "rotation", new Vector3(0f, 0f, -60.64f),
                "time", 1f,
                "delay", delay,
                "oncompletetarget", gameObject,
                "oncomplete", "Done"));
    }

    public void MovePlanesHorizontal()
    {
        menueAnimating = true;
        iTween.MoveTo(sidePanelRight,
            iTween.Hash(
                "position", new Vector3(500f, 450f) + GlobalRef.globalVariable.localPosition,
                "time", 1f));

        iTween.RotateTo(sidePanelRight,
            iTween.Hash(
                "rotation", new Vector3(0f, 0f, 90f),
                "time", 1f));

        iTween.MoveTo(sidePanelLeft,
            iTween.Hash(
                "position", new Vector3(-500f, -450f) + GlobalRef.globalVariable.localPosition,
                "time", 1f));

        iTween.RotateTo(sidePanelLeft,
            iTween.Hash(
                "rotation", new Vector3(0f, 0f, -90f),
                "time", 1f,
                "oncompletetarget", gameObject,
                "oncomplete", "Done"));
    }

    public void MoveInTutorial()
    {
        menueAnimating = true;
        iTween.MoveTo(tutorial,
            iTween.Hash(
                "position", new Vector3(0f + GlobalRef.globalVariable.localPosition.x, tutorial.transform.position.y),
                "delay", 1f,
                "time", 1f,
                "oncompletetarget", gameObject,
                "oncomplete", "DoneT"));
    }

    public void MoveOutTutorial()
    {
        menueAnimating = true;
        iTween.MoveTo(tutorial,
            iTween.Hash(
                "position", new Vector3(-2000f + GlobalRef.globalVariable.localPosition.x, tutorial.transform.position.y),
                "time", 1.5f,
                "oncompletetarget", gameObject,
                "oncomplete", "DoneT"));
    }

    public void Done()
    {
        menueAnimating = false;
        doDiagonal = false;
        doHorizontal = false;

        if (doTutorial && tutorial.transform.position.x == 2000f + GlobalRef.globalVariable.localPosition.x)
        {
            MoveInTutorial();
        }
    }

    public void DoneT()
    {
        if (tutorial.transform.position.x == -2000f + GlobalRef.globalVariable.localPosition.x)
        {
            tutorial.transform.position = new Vector3(2000f + GlobalRef.globalVariable.localPosition.x, tutorial.transform.position.y);
        }

        doTutorial = false;
        menueAnimating = false;
    }
}