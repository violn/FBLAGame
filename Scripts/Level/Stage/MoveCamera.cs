//Moves the camera with the player
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private float defaultYPosition;

    private void Start()
    {
        defaultYPosition = gameObject.transform.position.y;
    }

    private void Update()
    {
        if (GlobalRefLevel.player.transform.position.y > defaultYPosition)
        {
            iTween.MoveTo(gameObject, iTween.Hash("y", Mathf.Round(GlobalRefLevel.player.transform.position.y), "time", 1f));
        }
    }
}