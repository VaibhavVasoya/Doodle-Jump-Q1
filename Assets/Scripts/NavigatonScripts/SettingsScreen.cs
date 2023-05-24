using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsScreen : BaseClass
{

    [SerializeField] private Button HomeButton;



    // Start is called before the first frame update
    void Start()
    {
       HomeButton.onClick.AddListener(HomeBtn);


    }

    void HomeBtn()
    {
        ScreenManager.inst.ShowNextScreen(ScreenType.HomeScreen);
    }

   
}
