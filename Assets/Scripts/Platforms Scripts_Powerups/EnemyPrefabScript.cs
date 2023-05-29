using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPrefabScript : MonoBehaviour
{


    [SerializeField] private PowerUpsController powerUpsController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DownWall"))
        {
            Debug.Log("triggered");
            Destroy(gameObject);
            //gameObject.SetActive(false);


        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //BoxCollider2D boxCollider2D = collision.collider.GetComponent<BoxCollider2D>();
        //Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();

        if (PlayerController.inst._boxCollider2D != null)
        {
            PlayerController.inst._boxCollider2D.enabled = false;
        }
    }
}
