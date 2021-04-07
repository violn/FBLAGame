//Quits the game when escape is pressed

using UnityEngine;

public class Quit : MonoBehaviour
{
    public KeyCode quitGame;

    private void Update()
    {
        if (Input.GetKeyDown(quitGame))
        {
            Application.Quit();
        }
    }
}