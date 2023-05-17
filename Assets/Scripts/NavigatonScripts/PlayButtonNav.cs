using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButtonNav : MonoBehaviour
{

    [SerializeField] private Button PlayButton;
    [SerializeField] GameObject platformSpawner;
    // Start is called before the first frame update
    void Start()
    {
        PlayButton.onClick.AddListener(PlayBtn);
        platformSpawner.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayBtn()
    {
        PlayerController.inst.inputs = true;
        platformSpawner.SetActive(true);
        ScreenNavigator.inst.ShowNextScreen(ScreenType.GameScreen);
    }

   
}
