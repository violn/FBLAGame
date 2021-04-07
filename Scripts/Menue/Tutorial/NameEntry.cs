using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class NameEntry : MonoBehaviour
{
    public static string playerName;
    public InputField nameEntry;
    public Text inputMessage;
    public Text inputMessageFG;

    private void Update()
    {
        if (nameEntry.isFocused)
        {
            nameEntry.placeholder.GetComponent<Text>().text = "";
        }
        else nameEntry.placeholder.GetComponent<Text>().text = "Enter your name...";
    }

    public void SetPlayerName()
    {
        string n = nameEntry.text;
        if (NotEmpty(n))
        {
            playerName = nameEntry.text;
            Debug.Log("Player name is " + playerName + ".");
        }
        else
        {
            NameEntryWarning.TextColor = Color.red;
            inputMessage.text = "Please enter a valid name.";
            inputMessageFG.text = "Please enter a valid name.";
        }
    }

    public static bool NotEmpty(string s)
    {
        bool not_empty = false;

        if (s == null)
        {
            return false;
        }

        foreach (var _ in s.Where(c => c != ' ').Select(c => new { }))
        {
            not_empty = true;
        }

        return not_empty;
    }
}