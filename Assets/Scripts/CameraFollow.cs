using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] ScreenManager navigator;
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
            navigator.ShowGameOverScreen();
            Vector3 newPosition = new Vector3(transform.position.x, player.position.y, transform.position.z);
            transform.position = newPosition;
            player.gameObject.SetActive(false);
        }

    }
}
