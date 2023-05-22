using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtons : MonoBehaviour
{
    public Button[] buttons;
    public Button candiesAddbtn;
    private Button selectedButton;
    public Image InsufficientCandiesimg;


    public static ShopButtons inst;


    private void Awake()
    {
        inst = this;
    }

    private void Start()
    {
        InsufficientCandiesimg.gameObject.SetActive(false);
        candiesAddbtn.onClick.AddListener(AddCandies);

        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => ToggleSelection(button));
            
        }
    }

    private void ToggleSelection(Button clickedButton)
    {
        if (selectedButton == clickedButton)
        {
            selectedButton = null;
            clickedButton.GetComponentInChildren<Text>().text = "Select";
        }
        else
        {
            if (selectedButton != null)
            {
                selectedButton.GetComponentInChildren<Text>().text = "Select";
            }

            selectedButton = clickedButton;
            selectedButton.GetComponentInChildren<Text>().text = "Selected";
        }
    }

    public void ShowPopUp()
    {
        InsufficientCandiesimg.gameObject.SetActive(true);
    }

    public void HidePopUp()
    {
        InsufficientCandiesimg.gameObject.SetActive(false);
    }

    public void AddCandies()
    {
        Debug.Log("added");
        ScoreManager.instance.coin = ScoreManager.instance.coin + 20;
    }
}