using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButtonNav : MonoBehaviour
{

    [SerializeField] private Button MainMenuButton;


    // Start is called before the first frame update
    void Start()
    {
       MainMenuButton.onClick.AddListener(MainMenuBtn);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MainMenuBtn()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
        ScreenManager.inst.ShowNextScreen(ScreenType.HomeScreen);
    }

   
}
