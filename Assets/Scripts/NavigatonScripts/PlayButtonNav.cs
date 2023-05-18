using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButtonNav : MonoBehaviour
{

    [SerializeField] private Button PlayButton;
    [SerializeField] GameObject platformSpawner;

    void Start()
    {
        PlayButton.onClick.AddListener(PlayBtn);
        platformSpawner.SetActive(false);

    }

    void PlayBtn()
    {
        PlayerController.inst.inputs = true;
        platformSpawner.SetActive(true);
        ScreenManager.inst.ShowNextScreen(ScreenType.GameScreen);
    }

   
}
