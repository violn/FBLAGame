using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FinishGame : MonoBehaviour
{
    public GameObject leaderboard;
    public GameObject credits;
    public GameObject results;
    public Text dataTextFG;
    public Text dataTextBG;
    public static bool finishGame;
    public static int totalScore;

    public void Start()
    {
        finishGame = false;
    }

    public void Update()
    {
        if (finishGame)
        {
            finishGame = false;
            foreach (int s in FinishLevel.levelScores)
            {
                totalScore += s;
            }

            if(NameEntry.playerName == null)
            {
                NameEntry.playerName = "DefaultDan";
            }

            if (!ScoreHandler.scoreKeeper.ContainsKey(NameEntry.playerName))
            {
                ScoreHandler.scoreKeeper.Add(NameEntry.playerName, totalScore);
            }
            else
            {
                ScoreHandler.scoreKeeper[NameEntry.playerName] = ScoreHandler.scoreKeeper[NameEntry.playerName] < totalScore ? totalScore : ScoreHandler.scoreKeeper[NameEntry.playerName];
            }

            WriteDownScores();
            MoveCreditsIn();
        }
    }

    private void MoveCreditsIn()
    {
        iTween.MoveTo(results,
            iTween.Hash(
                "position", new Vector3(-500f, -1000f) + GlobalVariables.localPosition,
                "time", 1f));

        iTween.MoveTo(leaderboard,
            iTween.Hash(
                "position", new Vector3(500f, 0f) + GlobalVariables.localPosition,
                "time", 1f,
                "delay", .5));

        iTween.MoveTo(credits,
            iTween.Hash(
                "position", new Vector3(-500f, 0f) + GlobalVariables.localPosition,
                "time", 1f));
    }

    private void WriteDownScores()
    {
        Dictionary<string, int> sorted_scores = new Dictionary<string, int>();
        List<int> scores = (from KeyValuePair<string, int> entry in ScoreHandler.scoreKeeper
                            select entry.Value).ToList();
        scores.Sort();
        scores.Reverse();
        foreach (var entry in from int s in scores
                              from KeyValuePair<string, int> entry in ScoreHandler.scoreKeeper
                              where entry.Value == s && sorted_scores != null && !sorted_scores.ContainsKey(entry.Key)
                              select entry)
        {
            sorted_scores.Add(entry.Key, entry.Value);
        }

        foreach (KeyValuePair<string, int> entry in sorted_scores)
        {
            dataTextBG.text += $"{entry.Key} {entry.Value}\n";
            dataTextFG.text += $"{entry.Key} {entry.Value}\n";
        }

        ScoreHandler.Save();
    }
}
