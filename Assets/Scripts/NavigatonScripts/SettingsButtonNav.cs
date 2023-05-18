using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsButtonNav : MonoBehaviour
{

    [SerializeField] private Button SettingsButton;


    // Start is called before the first frame update
    void Start()
    {
       SettingsButton.onClick.AddListener(SettingsBtn);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SettingsBtn()
    {
        ScreenManager.inst.ShowNextScreen(ScreenType.SettingsScreen);
    }

   
}
