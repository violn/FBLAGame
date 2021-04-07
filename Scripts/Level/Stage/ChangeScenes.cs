using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public GameObject results;
    public GameObject leaderboard;

    private void Restart()
    {
        if (Fail.inFail)
        {
            Lives.liveRemaining--;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Next()
    {
        Lives.liveRemaining = 3;
        Lives.resetLives = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void ToMenue()
    {
        Lives.liveRemaining = 3;
        Lives.resetLives = true;
        SceneManager.LoadScene(1);
    }

    public void StartRestart()
    {
        iTween.MoveTo(GlobalRefLevel.globalObj.sidePanelRight,
            iTween.Hash(
                "position", new Vector3(500f, -550f) + GlobalRef.globalVariable.localPosition,
                "time", 1f));

        iTween.MoveTo(GlobalRefLevel.globalObj.sidePanelLeft,
            iTween.Hash(
                "position", new Vector3(-500f, -1000f) + GlobalRef.globalVariable.localPosition,
                "time", 1f,
                "oncompletetarget", gameObject,
                "oncomplete", "Restart"));
    }

    public void StartNext()
    {
        if (GlobalRefLevel.levelProperties.currentLevel != SceneManager.sceneCountInBuildSettings - 2)
        {
            iTween.MoveTo(GlobalRefLevel.globalObj.sidePanelRight,
                iTween.Hash(
                    "position", new Vector3(500f, -550f) + GlobalRef.globalVariable.localPosition,
                    "time", 1f));

            iTween.MoveTo(GlobalRefLevel.globalObj.sidePanelLeft,
                iTween.Hash(
                    "position", new Vector3(-500f, -1000f) + GlobalRef.globalVariable.localPosition,
                    "time", 1f,
                    "oncompletetarget", gameObject,
                    "oncomplete", "Next"));
        }
        else
        {
            FinishGame.finishGame = true;
        }
    }

    public void StartMenue()
    {
        iTween.MoveTo(GlobalRefLevel.globalObj.sidePanelRight,
            iTween.Hash(
                "position", new Vector3(500f, -550f) + GlobalRef.globalVariable.localPosition,
                "time", 1f));

        iTween.MoveTo(GlobalRefLevel.globalObj.sidePanelLeft,
            iTween.Hash("position", new Vector3(-500f, -1000f) + GlobalRef.globalVariable.localPosition,
            "time", 1f,
            "oncompletetarget", gameObject,
            "oncomplete", "ToMenue"));
    }
}