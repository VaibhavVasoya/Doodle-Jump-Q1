using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        PlayerController.inst.MainMenu();
    }

    void PlayAgainBtn()
    {
        PlayerController.inst.RestartGame();
    }

}
