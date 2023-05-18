using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformVertical : MonoBehaviour
{

    [SerializeField] private bool movingUp = true;
    [SerializeField] private float jumpForce;
    private float StartPos;

    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

        if (movingUp == true)
        {
           

            transform.Translate(Vector2.up * 1f * Time.deltaTime);
            if (transform.position.y >= StartPos + 1f)
            {
                movingUp = false;
            }
        }
        else
        {
            transform.Translate(Vector2.down * 1f * Time.deltaTime);
            if(transform.position.y <= StartPos - 1f)
            {
                movingUp = true;
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                AudioManager.instance.Play("DoodleJump");
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;

            }
        }
    }



}
