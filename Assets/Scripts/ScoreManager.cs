using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreTextOnGameOver;
    public Text scoreTextOnGameplay;
    public Text scoreTectOnPause;
    public Text highScoreText;
    public Text highScoreTextOnScorePage;
    public Text coinText;
    public Text CanbdiesText;
    public int score;
    public int coin;
    public int highScore;
    public int Candies;

    public static ScoreManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        score = 0;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        coin = PlayerPrefs.GetInt("Coins", 0);
        UpdateScoreText();
        UpdateHighScoreText();
        Candies = coin * 2;
    }

    void Update()
    {
        UpdateScoreText();
        UpdateHighScoreText();
        UpdateCoinText();
        UpdateCandiesText();

        Candies = coin * 2;

        // score += points;
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            UpdateHighScoreText();
        }

        PlayerPrefs.SetInt("Coins", coin);

    }

    private void UpdateScoreText()
    {
        scoreTextOnGameOver.text = score.ToString();
        scoreTextOnGameplay.text = score.ToString();
        scoreTectOnPause.text = score.ToString();

    }

    private void UpdateHighScoreText()
    {
        highScoreText.text = highScore.ToString();
        highScoreTextOnScorePage.text = highScore.ToString();
    }

    private void UpdateCoinText()
    {
        coinText.text = coin.ToString();
    }

    private void UpdateCandiesText()
    {
        CanbdiesText.text = Candies.ToString();
    }
}
