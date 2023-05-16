using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShopManager : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private Button Bunnybuybutton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void BuyBunntyDoodle()
    {
        if(scoreManager.Candies >= 20)
        {
            Debug.Log("bunny buyed");
            Bunnybuybutton.gameObject.SetActive(false);
            scoreManager.coin -= 10;
        }
        else
        {
            Debug.Log("Not enough Candies");
        }
    }

}
