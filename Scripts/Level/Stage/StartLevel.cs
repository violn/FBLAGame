//Starts the level by finishing the last scene's transition

using UnityEngine;

public class StartLevel : MonoBehaviour
{
    public static bool levelStarted;
    public GameObject results;
    public GameObject fail;

    private void Start()
    {
        levelStarted = false;
        results.transform.localScale = new Vector3(0f, 0f);
        fail.transform.localScale = new Vector3(0f, 0f);

        iTween.MoveTo(GlobalRefLevel.globalObj.sidePanelLeft,
            iTween.Hash(
                "position", new Vector3(GlobalRefLevel.globalObj.sidePanelLeft.transform.position.x, -600f + GlobalRef.globalVariable.localPosition.y),
                "delay", .5f,
                "easeType", "easeOutBack",
                "time", 1f,
                "oncompletetarget", gameObject,
                "oncomplete", "LevelStart"));
    }

    public void LevelStart()
    {
        levelStarted = true;
    }
}