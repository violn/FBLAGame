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
    private List<GameObject> screens = new List<GameObject>();
    private int currentScreen;

    private void Start()
    {
        screens.Add(basicMove);
        screens.Add(depthMove);
        screens.Add(grabbing);
        screens.Add(goal);
        currentScreen = 1;

        DisplayScreen();
    }

    public void GoNext()
    {
        if (currentScreen == screens.Count)
        {
            currentScreen = 1;
        }
        else currentScreen++;

        DisplayScreen();
    }

    public void GoBack()
    {
        if (currentScreen == 1)
        {
            currentScreen = screens.Count;
        }
        else currentScreen--;

        DisplayScreen();
    }

    private void DisplayScreen()
    {
        for (int x = 0; x < screens.Count; x++)
        {
            if (x != currentScreen - 1)
            {
                screens[x].SetActive(false);
            }
            else
            {
                screens[x].SetActive(true);
            }
        }

        bottomTextBG.text = screens[currentScreen - 1].name;
        bottomTextFG.text = screens[currentScreen - 1].name;
    }
}