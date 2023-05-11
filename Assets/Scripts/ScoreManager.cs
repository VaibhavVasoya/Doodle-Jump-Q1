using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreTextOnGameOver;
    public Text scoreTextOnGameplay;
    public Text scoreTectOnPause;
    public Text highScoreText;
    public int score;
    public int highScore;

    private void Start()
    {
        score = 0;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateScoreText();
        UpdateHighScoreText();
    }

    void Update()
    {
        UpdateScoreText();
        UpdateHighScoreText();

        // score += points;
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            UpdateHighScoreText();
        }

    }

    private void UpdateScoreText()
    {
        scoreTextOnGameOver.text = "Score: " + score.ToString();
        scoreTextOnGameplay.text = score.ToString();
        scoreTectOnPause.text = score.ToString();

    }

    private void UpdateHighScoreText()
    {
        highScoreText.text = "High Score: " + highScore.ToString();
    }
}
