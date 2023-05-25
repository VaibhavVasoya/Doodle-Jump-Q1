using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : BaseClass
{


    [SerializeField] private Button MainMenuButton;
    [SerializeField] private Button PlayAgainButton;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _platforms;
    [SerializeField] private GameObject _spawnedPlatforms;
    [SerializeField] private Camera _camera;
    


    // Start is called before the first frame update
    public void Start()
    {
        MainMenuButton.onClick.AddListener(MainMenuBtn);
        PlayAgainButton.onClick.AddListener(PlayAgainBtn);

    }

    void MainMenuBtn()
    {
        _player.transform.position = new Vector3(-1.75800002f, -2.19109917f, 0);
        _camera.transform.position = new Vector3(0, 0, -10);
        _player.SetActive(true);
        _platforms.SetActive(true);
        _spawnedPlatforms.SetActive(false);
        PlayerController.inst.inputs = false;
        PlatformSpawner.inst.LastSpawn = PlatformSpawner.inst.playerTransform.position.y - PlatformSpawner.inst.spawnDistance;
        ScreenManager.inst.ShowNextScreen(ScreenType.HomeScreen);
        ScoreManager.instance.score = 0;
    }

    void PlayAgainBtn()
    {
        _player.transform.position = new Vector3(-1.75800002f, -2.19109917f, 0);
        _camera.transform.position = new Vector3(0, 0, -10);
        ScoreManager.instance.score = 0;
        _player.SetActive(true);

        PlatformSpawner.inst.LastSpawn = PlatformSpawner.inst.playerTransform.position.y - PlatformSpawner.inst.spawnDistance;


        ScreenManager.inst.ShowNextScreen(ScreenType.GameScreen);
    }

    //public void MainMenu()
    //{
    //    _player.transform.position = new Vector3(-1.75800002f, -2.19109917f, 0);
    //    _camera.transform.position = new Vector3(0, 0, -10);
    //    _player.SetActive(true);
    //    _platforms.SetActive(true);
    //    _spawnedPlatforms.SetActive(false);
    //    PlayerController.inst.inputs = false;
    //    PlatformSpawner.inst.LastSpawn = PlatformSpawner.inst.playerTransform.position.y - PlatformSpawner.inst.spawnDistance;

    //}
}
