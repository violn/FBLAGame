using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject basicMove;
    public GameObject depthMove;
    public GameObject grabbing;
    public GameObject goal;
    public TextMeshProUGUI bottomTextFG;
    public TextMeshProUGUI bottomTextBG;
    private readonly List<GameObject> screens = new List<GameObject>();
    private int currentScreen;

    private void Start()
    {
        screens.Clear();
        screens.Add(basicMove);
        screens.Add(depthMove);
        screens.Add(grabbing);
        screens.Add(goal);
        currentScreen = 1;

        DisplayScreen();
    }

    public void GoNext()
    {
        currentScreen = currentScreen == screens.Count ? 1 : currentScreen++;
        DisplayScreen();
    }

    public void GoBack()
    {
        currentScreen = currentScreen == screens.Count ? screens.Count : currentScreen--;
        DisplayScreen();
    }

    private void DisplayScreen()
    {
        for (int x = 0; x < screens.Count; x++)
        {
            screens[x].SetActive(!(x != currentScreen - 1));
        }

        bottomTextFG.text = bottomTextBG.text = screens[currentScreen - 1].name;
    }
}
