using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShopManager : MonoBehaviour
{
    public Button DoodleBtn;
    [SerializeField] private int CandiesCount;

    


    // Start is called before the first frame update
    void Start()
    {
        DoodleBtn.onClick.AddListener(BuyBunnyDoodle);

    }




    void BuyBunnyDoodle()
    {
        if (ScoreManager.instance.Candies >= CandiesCount)
        {
            SpriteManager.inst.ChangeSprite = true;
            Debug.Log("bunny buyed");
            DoodleBtn.gameObject.SetActive(false);
            ScoreManager.instance.coin -= CandiesCount/2;
        }
        else
        {
            Debug.Log("Not enough Candies");

        }
    }

}
