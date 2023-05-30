using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDisable : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Platform") ||
           collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.CompareTag("RestartPlatform"))
        {
            collision.gameObject.SetActive(false);
        }
    }

}
