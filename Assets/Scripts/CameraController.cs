using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;

    void LateUpdate()
    {
        if(player.position.y > transform.position.y)
        {
            Vector3 newPosition = new Vector3(transform.position.x, player.position.y,transform.position.z);
            transform.position = newPosition;
        }
        if(player.position.y < transform.position.y - 8f)
        {
            ScreenManager.inst.ShowNextScreen(ScreenType.GameOverScreen);
            AudioManager.instance.Play("Fall");
            Vector3 newPosition = new Vector3(transform.position.x, player.position.y, transform.position.z);
            transform.position = newPosition;
            Invoke("Fall", 0.5f);
        }

    }


    public void Fall()
    {
        player.gameObject.SetActive(false);
        CancelInvoke();
    }


}
