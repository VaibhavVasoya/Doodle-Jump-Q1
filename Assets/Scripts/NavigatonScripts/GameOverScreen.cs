using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : BaseClass
{


    [SerializeField] private Button MainMenuButton;
    [SerializeField] private Button PlayAgainButton;

    // Start is called before the first frame update
    public void Start()
    {
        MainMenuButton.onClick.AddListener(MainMenuBtn);
        PlayAgainButton.onClick.AddListener(PlayAgainBtn);

    }

    void MainMenuBtn()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
        ScreenManager.inst.ShowNextScreen(ScreenType.HomeScreen);
    }

    void PlayAgainBtn()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
        ScreenManager.inst.ShowNextScreen(ScreenType.HomeScreen);
    }
}
