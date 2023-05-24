using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScreen : BaseClass
{

    [SerializeField] GameObject platformSpawner;
    [SerializeField] private Button PlayButton;
    [SerializeField] private Button ScoreButton;
    [SerializeField] private Button SettingsButton;
    [SerializeField] private Button StoreButton;


    void Start()
    {
        platformSpawner.SetActive(false);

        PlayButton.onClick.AddListener(PlayBtn);
        ScoreButton.onClick.AddListener(ScoreBtn);
        SettingsButton.onClick.AddListener(SettingsBtn);
        StoreButton.onClick.AddListener(StoreBtn);

    }



    void PlayBtn()
    {
        PlayerController.inst.inputs = true;
        platformSpawner.SetActive(true);
        ScreenManager.inst.ShowNextScreen(ScreenType.GameScreen);
    }


    void ScoreBtn()
    {
        ScreenManager.inst.ShowNextScreen(ScreenType.ScoreScreen);
    }

    void SettingsBtn()
    {
        ScreenManager.inst.ShowNextScreen(ScreenType.SettingsScreen);
    }
    void StoreBtn()
    {
        ScreenManager.inst.ShowNextScreen(ScreenType.ShopScreen);
    }


}
