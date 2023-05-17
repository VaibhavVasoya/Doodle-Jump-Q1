using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResumeButtonNav : MonoBehaviour
{

    [SerializeField] private Button ResumeButton;


    // Start is called before the first frame update
    void Start()
    {
        ResumeButton.onClick.AddListener(ResumeBtn);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ResumeBtn()
    {
        Time.timeScale = 1;
        ScreenNavigator.inst.ShowNextScreen(ScreenType.GameScreen);
    }

   
}
