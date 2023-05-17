using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoreButtonNav : MonoBehaviour
{

    [SerializeField] private Button StoreButton;


    // Start is called before the first frame update
    void Start()
    {
       StoreButton.onClick.AddListener(StoreBtn);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StoreBtn()
    {
        ScreenNavigator.inst.ShowNextScreen(ScreenType.ShopScreen);
    }

   
}
