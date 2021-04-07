using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishGame : MonoBehaviour
{
    public GameObject leaderboard;
    public GameObject credits;
    public GameObject results;
    public Text data;
    public Text dataFG;
    public static bool finishGame = false;
    public static int totalScore;

    public void Start()
    {
        finishGame = false;
    }

    public void Update()
    {
        if (finishGame == true)
        {
            finishGame = false;
            foreach (int s in GlobalRef.levelScores)
            {
                totalScore += s;
            }

            if (ScoreHandler.scoreKeeper != null && !ScoreHandler.scoreKeeper.ContainsKey(NameEntry.playerName))
            {
                ScoreHandler.scoreKeeper.Add(NameEntry.playerName, totalScore);
            }
            else
            {
                int existing_score = ScoreHandler.scoreKeeper[NameEntry.playerName];

                if (existing_score < totalScore)
                {
                    ScoreHandler.scoreKeeper[NameEntry.playerName] = totalScore;
                }
            }

            WriteDownScores();
            MoveThingsIn();
        }
    }

    public void MoveThingsIn()
    {
        iTween.MoveTo(results,
            iTween.Hash(
                "position", new Vector3(-500f, -1000f) + GlobalRef.globalVariable.localPosition,
                "time", 1f));

        iTween.MoveTo(leaderboard,
            iTween.Hash(
                "position", new Vector3(500f, 0f) + GlobalRef.globalVariable.localPosition,
                "time", 1f,
                "delay", .5));

        iTween.MoveTo(credits,
            iTween.Hash(
                "position", new Vector3(-500f, 0f) + GlobalRef.globalVariable.localPosition,
                "time", 1f));
    }

    public void WriteDownScores()
    {
        List<int> scores = new List<int>();
        Dictionary<string, int> sorted_scores = new Dictionary<string, int>();

        foreach (KeyValuePair<string, int> entry in ScoreHandler.scoreKeeper)
        {
            scores.Add(entry.Value);
        }

        scores.Sort();
        scores.Reverse();

        foreach (int s in scores)
        {
            foreach (KeyValuePair<string, int> entry in ScoreHandler.scoreKeeper)
            {
                if (entry.Value == s && sorted_scores != null && !sorted_scores.ContainsKey(entry.Key))
                {
                    sorted_scores.Add(entry.Key, entry.Value);
                }
            }
        }

        foreach (KeyValuePair<string, int> entry in sorted_scores)
        {
            data.text += entry.Key + " " + entry.Value + "\n";
            dataFG.text += entry.Key + " " + entry.Value + "\n";
        }

        ScoreHandler.Save();
    }
}