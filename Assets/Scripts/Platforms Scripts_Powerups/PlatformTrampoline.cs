using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrampoline : MonoBehaviour
{

    [SerializeField] private float jumpForce;

    private void OnCollisionEnter2D(Collision2D collision)
    {

            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null && rb.velocity.y <= 0)
            {
                AudioManager.instance.Play("Trampoline");
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;

            }
   
    }
}