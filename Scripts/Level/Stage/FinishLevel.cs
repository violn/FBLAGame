//Finishes the level and allows the player to either go to the next level or restart the level
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    public static bool inResults;
    public static int score;
    public TextMeshProUGUI congratsMessage;
    public TextMeshProUGUI congratsMessageFG;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreTextFG;
    public TextMeshProUGUI highscoreText;
    public TextMeshProUGUI highscoreTextFG;

    private void Start()
    {
        inResults = false;

        PlayerPrefs.SetInt("Bestscore 1", 0);
        PlayerPrefs.SetInt("Bestscore 2", 0);
        PlayerPrefs.SetInt("Bestscore 3", 0);

        if (GlobalRefLevel.levelProperties.currentLevel == SceneManager.sceneCountInBuildSettings - 2)
        {
            congratsMessage.text = "All levels completed!";
            congratsMessageFG.text = "All levels completed!";
        }
    }

    private void Update()
    {
        if (!Fail.inFail)
        {
            if (!GlobalRefLevel.playerProperties.moving && OnFinalBlock() && !inResults)
            {
                inResults = true;

                score = 9999 - (9999 / GlobalRefLevel.levelProperties.stageCompleteTime * Timer.secondsElapsed);

                if (score < 0)
                {
                    score = 0;
                }

                scoreText.text = "Score: " + score;
                scoreTextFG.text = "Score: " + score;

                if (GlobalRef.levelScores[GlobalRefLevel.levelProperties.currentLevel - 1] == 0)
                {
                    GlobalRef.levelScores[GlobalRefLevel.levelProperties.currentLevel - 1] = score;
                }
                else if (GlobalRef.levelScores[GlobalRefLevel.levelProperties.currentLevel - 1] < score)
                {
                    GlobalRef.levelScores[GlobalRefLevel.levelProperties.currentLevel - 1] = score;
                }

                switch (GlobalRefLevel.levelProperties.currentLevel)
                {
                    case 1:
                        if (score > PlayerPrefs.GetInt("Bestscore 1"))
                        {
                            highscoreText.text = "Best Score: " + score;
                            highscoreTextFG.text = "Best Score: " + score;
                            PlayerPrefs.SetInt("Bestscore 1", score);
                        }
                        else
                        {
                            highscoreText.text = "Best Score: " + PlayerPrefs.GetInt("Bestscore 1");
                            highscoreTextFG.text = "Best Score: " + PlayerPrefs.GetInt("Bestscore 1");
                        }
                        break;

                    case 2:
                        if (score > PlayerPrefs.GetInt("Bestscore 2"))
                        {
                            highscoreText.text = "Best Score: " + score;
                            highscoreTextFG.text = "Best Score: " + score;
                            PlayerPrefs.SetInt("Bestscore 2", score);
                        }
                        else
                        {
                            highscoreText.text = "Best Score: " + PlayerPrefs.GetInt("Bestscore 2");
                            highscoreTextFG.text = "Best Score: " + PlayerPrefs.GetInt("Bestscore 2");
                        }
                        break;

                    case 3:
                        if (score > PlayerPrefs.GetInt("Bestscore 3"))
                        {
                            highscoreText.text = "Best Score: " + score;
                            highscoreTextFG.text = "Best Score: " + score;
                            PlayerPrefs.SetInt("Bestscore 3", score);
                        }
                        else
                        {
                            highscoreText.text = "Best Score: " + PlayerPrefs.GetInt("Bestscore 3");
                            highscoreTextFG.text = "Best Score: " + PlayerPrefs.GetInt("Bestscore 3");
                        }
                        break;
                }

                if (inResults)
                {
                    if (Fade.fade_color.a < .4f)
                    {
                        Fade.FadeIn();
                    }
                }

                GlobalRef.globalMethod.SidePanelsMoveIn();
                ExpandResults();
            }
        }
    }

    public void ExpandResults()
    {
        iTween.ScaleTo(gameObject,
            iTween.Hash(
                "scale", new Vector3(1.7f, 1.7f, 1f),
                "time", .75f));

        iTween.RotateTo(gameObject,
            iTween.Hash(
                "rotation", new Vector3(0f, 0f, 0f),
                "time", .75f,
                "easetype", "easeoutback"));
    }

    public bool OnFinalBlock()
    {
        GameObject final_block;

        if (GlobalRefLevel.objectMove.CheckCollision(GlobalRefLevel.player, GlobalRef.globalLayer.depth0, 0f, -1f))
        {
            Collider2D BlockCollider = Physics2D.OverlapCircle(GlobalRefLevel.player.transform.position + new Vector3(0f, -1f), .001f, GlobalRef.globalLayer.depth0);
            final_block = BlockCollider.gameObject;

            if (final_block.GetComponent<UpdateBlock>() != null && final_block.GetComponent<UpdateBlock>().blockType == 1)
            {
                return true;
            }
        }
        else if (GlobalRefLevel.objectMove.CheckCollision(GlobalRefLevel.player, GlobalRef.globalLayer.depth1, 0f, -1f))
        {
            Collider2D BlockCollider = Physics2D.OverlapCircle(GlobalRefLevel.player.transform.position + new Vector3(0f, -1f), .001f, GlobalRef.globalLayer.depth1);
            final_block = BlockCollider.gameObject;

            if (final_block.GetComponent<UpdateBlock>() != null && final_block.GetComponent<UpdateBlock>().blockType == 1)
            {
                return true;
            }
        }

        return false;
    }
}