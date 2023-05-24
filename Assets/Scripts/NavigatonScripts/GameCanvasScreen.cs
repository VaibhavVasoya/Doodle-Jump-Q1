using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvasScreen : BaseClass
{

    [SerializeField] private Button PauseButton;


    // Start is called before the first frame update
    void Start()
    {
        PauseButton.onClick.AddListener(PauseBtn);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PauseBtn()
    {
        Time.timeScale = 0;
        ScreenManager.inst.ShowNextScreen(ScreenType.PauseScreen);
    }

   
}
