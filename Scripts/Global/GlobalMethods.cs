using UnityEngine;

public class GlobalMethods : MonoBehaviour
{
    public void SidePanelsMoveIn()
    {
        iTween.MoveTo(GlobalRefLevel.globalObj.sidePanelLeft,
            iTween.Hash(
                "position", new Vector3(GlobalRefLevel.globalObj.sidePanelLeft.transform.position.x, -450 + GlobalRef.globalVariable.localPosition.y),
                "easeType", "easeOutBack",
                "time", .5f));

        iTween.MoveTo(GlobalRefLevel.globalObj.sidePanelRight,
            iTween.Hash(
                "position", new Vector3(GlobalRefLevel.globalObj.sidePanelRight.transform.position.x, 450 + GlobalRef.globalVariable.localPosition.y),
                "easeType", "easeOutBack",
                "time", .5f));
    }

    public void SidePanelsMoveOut()
    {
        iTween.MoveTo(GlobalRefLevel.globalObj.sidePanelLeft,
            iTween.Hash(
                "position", new Vector3(GlobalRefLevel.globalObj.sidePanelLeft.transform.position.x, -600 + GlobalRef.globalVariable.localPosition.y),
                "easeType", "easeOutBack",
                "time", .5f));

        iTween.MoveTo(GlobalRefLevel.globalObj.sidePanelRight,
            iTween.Hash(
                "position", new Vector3(GlobalRefLevel.globalObj.sidePanelRight.transform.position.x, 600 + GlobalRef.globalVariable.localPosition.y),
                "easeType", "easeOutBack",
                "time", .5f));
    }
}