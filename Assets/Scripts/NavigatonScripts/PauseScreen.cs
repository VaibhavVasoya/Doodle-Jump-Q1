using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScreen : BaseClass
{

    [SerializeField] private Button ResumeButton;
    [SerializeField] private Button MainMenuButton;


    // Start is called before the first frame update
    void Start()
    {
        ResumeButton.onClick.AddListener(ResumeBtn);
        MainMenuButton.onClick.AddListener(MainMenuBtn);


    }

    void ResumeBtn()
    {
        Time.timeScale = 1;
        ScreenManager.inst.ShowNextScreen(ScreenType.GameScreen);
    }


    void MainMenuBtn()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
        ScreenManager.inst.ShowNextScreen(ScreenType.HomeScreen);
    }


}
