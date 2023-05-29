using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    [SerializeField] private float jumpForce;


    private void OnCollisionEnter2D(Collision2D collision)
    {
    
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();

            if (rb != null && rb.velocity.y <= 0)
            {   
                    AudioManager.instance.Play("DoodleJump");
                    Vector2 velocity = rb.velocity;
                    velocity.y = jumpForce;
                    rb.velocity = velocity;            
            }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DownWall"))
        {
            Debug.Log("triggered");
            Destroy(gameObject);
            //gameObject.SetActive(false);
        }
    }


}
