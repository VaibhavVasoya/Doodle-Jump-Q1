using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float playerSpeed;
    [SerializeField] Transform player;
    [SerializeField] Transform walls;
    [SerializeField] bool facingRight = true;
    //[SerializeField] float jumpPower; 
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");

        //rb.velocity = new Vector2(horizontalInput * playerSpeed, rb.velocity.y);
        float tilt = Input.acceleration.x;

        rb.velocity = new Vector2(tilt * playerSpeed, rb.velocity.y);


        walls.transform.position = new Vector3(walls.transform.position.x, player.position.y, walls.transform.position.z);

        //if(horizontalInput > 0 && !facingRight)
        //{
        //    flip();
        //}

        //if(horizontalInput < 0 && facingRight)
        //{
        //    flip();
        //}

        if (tilt > 0 && !facingRight)
        {
            flip();
        }

        if (tilt < 0 && facingRight)
        {
            flip();
        }

    }



    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.CompareTag("ground"))
    //    {
    //        rb.velocity = Vector2.up * jumpPower;
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LeftWall"))
        {
            transform.position = new Vector3(3f, transform.position.y, transform.position.z);
        }

        if (collision.gameObject.CompareTag("RightWall"))
        {
            transform.position = new Vector3(-3f, transform.position.y, transform.position.z);
        }
    }



    public void flip()
    {
        Vector2 currentscale = gameObject.transform.localScale;
        currentscale.x = currentscale.x * -1;
        gameObject.transform.localScale = currentscale;
        facingRight = !facingRight;

    }


}