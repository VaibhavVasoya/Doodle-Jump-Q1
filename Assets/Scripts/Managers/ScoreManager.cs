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
    public Text CandiesTextOnScoreScreen;
    public Text CoinTextOnScoreScreen;
    public int score;
    public int coin;
    public int highScore;
    public int Candies = 100;
    private int currentScore;

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
        UpdateCoinText();

    }


    void Update()
    {
        UpdateScoreText();
        UpdateHighScoreText();
        UpdateCandiesText();
        HighScore();


        Candies = coin * 2;

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            UpdateHighScoreText();
        }

        PlayerPrefs.SetInt("Coins", coin);

    }

    public void HighScore()
    {
        currentScore = Mathf.RoundToInt(PlayerController.inst._player.position.y);
        if (currentScore > score)
        {
            score = currentScore;
        }
    }

    public void UpdateScoreText()
    {
        scoreTextOnGameOver.text = score.ToString();
        scoreTextOnGameplay.text = score.ToString();
        scoreTectOnPause.text = score.ToString();
        

    }

    public void UpdateHighScoreText()
    {
        highScoreText.text = highScore.ToString();
        highScoreTextOnScorePage.text = highScore.ToString();
    }

    public void UpdateCoinText()
    {
        coinText.text = coin.ToString();
        CoinTextOnScoreScreen.text = coin.ToString();
    }

    public void UpdateCandiesText()
    {
        CanbdiesText.text = Candies.ToString();
        CandiesTextOnScoreScreen.text = Candies.ToString();
    }
}
