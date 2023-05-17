using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void LateUpdate()
    {
        if(player.position.y > transform.position.y)
        {
            Vector3 newPosition = new Vector3(transform.position.x, player.position.y,transform.position.z);
            transform.position = newPosition;
        }
        if(player.position.y < transform.position.y - 10f)
        {
            ScreenNavigator.inst.ShowNextScreen(ScreenType.GameOverScreen);
            Vector3 newPosition = new Vector3(transform.position.x, player.position.y + 10f, transform.position.z);
            transform.position = newPosition;
            player.gameObject.SetActive(false);
        }

    }
}
