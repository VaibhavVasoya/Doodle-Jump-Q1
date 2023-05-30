using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpring : MonoBehaviour
{

    [SerializeField] private Animator springAnim; 


    private void OnCollisionEnter2D(Collision2D collision)
    {

            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null && rb.velocity.y <= 0f)
            {
                AudioManager.instance.Play("Spring");
                Vector2 velocity = rb.velocity;
                velocity.y = PlayerController.inst._jumpForceSpring;
                rb.velocity = velocity;
                springAnim.SetTrigger("Spring");

            }
        }
 
}