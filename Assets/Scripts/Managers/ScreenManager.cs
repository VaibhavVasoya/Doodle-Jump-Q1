using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public BaseClass[] screens;
    public BaseClass currentScreen;
    public static ScreenManager inst;

        
    private void Awake()
    {
        inst = this;
    }



    private void Start()
    {
        currentScreen.canvas.enabled = true;
    }

    public void ShowNextScreen(ScreenType screenType)
    {
        currentScreen.canvas.enabled = false;

        foreach (BaseClass baseScreen in screens)
        {
            if (baseScreen.screenType == screenType)
            {
                baseScreen.canvas.enabled = true;
                currentScreen = baseScreen;
                break;
            }

        }

        switch (screenType)
        {
            case ScreenType.GameScreen:
                PlayerController.inst.OnMovement += PlayerController.inst.Windowsinputs;
                //PlayerController.inst.OnMovement += PlayerController.inst.AndroidInputs;
                break;

            case ScreenType.GameOverScreen:
                PlayerController.inst.OnMovement = null;
                break;

          

            


        }
    }
}
