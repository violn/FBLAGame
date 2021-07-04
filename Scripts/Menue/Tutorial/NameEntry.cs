using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameEntry : MonoBehaviour
{
    public static string playerName;
    public InputField nameEntry;
    public Text inputMessageFG;
    public Text inputMessageBG;

    private void Update()
    {
        nameEntry.placeholder.GetComponent<Text>().text = nameEntry.isFocused ? "" : "Enter your name...";
    }

    public void SetPlayerName()
    {
        if (NotEmpty(nameEntry.text))
        {
            playerName = nameEntry.text;
            Debug.Log("Player name is " + playerName + ".");
        }
        else
        {
            NameEntryWarning.TextColor = Color.red;
            inputMessageFG.text = inputMessageBG.text = "Please enter a valid name.";
        }
    }

    public static bool NotEmpty(string s)
    {
        return s.Split(' ').Length != 0;
    }
}
