using UnityEngine;

public class StartLevel : MonoBehaviour
{
    public GameObject results;
    public GameObject fail;

    private void Start()
    {
        results.transform.localScale = new Vector3(0f, 0f);
        fail.transform.localScale = new Vector3(0f, 0f);

        iTween.MoveTo(GlobalRefLevel.globalObj.sidePanelLeft,
            iTween.Hash(
                "position", new Vector3(GlobalRefLevel.globalObj.sidePanelLeft.transform.position.x, -600f + GlobalVariables.localPosition.y),
                "delay", .5f,
                "easeType", "easeOutBack",
                "time", 1f,
                "oncompletetarget", gameObject,
                "oncomplete", "LevelStart"));
    }

    private void LevelStart()
    {
        PlayerProps.still = true;
    }
}
