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

    void PauseBtn()
    {
        PlayerController.inst.PauseGame();
    }

   
}
