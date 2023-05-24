using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseClass : MonoBehaviour
{
    [HideInInspector]
    public Canvas canvas;
    
    public ScreenType screenType;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }

    private void Start()
    {
        Debug.LogError("Base");
    }
}

public enum ScreenType
{
    HomeScreen,
    GameScreen,
    PauseScreen,
    GameOverScreen,
    ShopScreen,
    SettingsScreen,
    ScoreScreen
}
