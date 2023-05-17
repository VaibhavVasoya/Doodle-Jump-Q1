using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreButtonNav : MonoBehaviour
{

    [SerializeField] private Button ScoreButton;


    // Start is called before the first frame update
    void Start()
    {
       ScoreButton.onClick.AddListener(ScoreBtn);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ScoreBtn()
    {
        ScreenNavigator.inst.ShowNextScreen(ScreenType.ScoreScreen);
    }

   
}
