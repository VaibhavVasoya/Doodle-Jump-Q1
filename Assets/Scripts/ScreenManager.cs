using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{

    [SerializeField] private Canvas MainMenuCanvas = default;
    [SerializeField] private Canvas GamePlayCanvas = default;
    [SerializeField] private Canvas PauseCanvas = default;
    [SerializeField] private Canvas GameOverCanvas = default;
    [SerializeField] GameObject PlatformSpawn;
    [SerializeField] private PlayerController playerController;


    // Start is called before the first frame update    private void Start()
    void Start()
    {
        
        ShowScreen(MainMenuCanvas);
        PlatformSpawn.SetActive(false);
    }

    public void ShowMainMenuCanvas()
    {
        ShowScreen(MainMenuCanvas);
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;

    }
    public void ShowGamePlayCanvas()
    {
        ShowScreen(GamePlayCanvas);
        PlatformSpawn.SetActive(true);
        Time.timeScale = 1;
        playerController.inputs = true;

    }
    public void ShowpauseCanvas()
    {
        ShowScreen(PauseCanvas);
        Time.timeScale = 0;
    }

    public void ShowGameOverScreen()
    {
        ShowScreen(GameOverCanvas);
    }

    private void ShowScreen(Canvas screen)
    {
        MainMenuCanvas.enabled = false;
        GamePlayCanvas.enabled = false;
        PauseCanvas.enabled = false;
        GameOverCanvas.enabled = false;
  
        screen.enabled = true;
    }

}


