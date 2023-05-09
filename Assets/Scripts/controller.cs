using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float playerSpeed;
    [SerializeField] Transform player;
    [SerializeField] Transform walls;
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

        rb.velocity = new Vector2(horizontalInput * playerSpeed, rb.velocity.y);


        walls.transform.position = new Vector3(walls.transform.position.x, player.position.y, walls.transform.position.z);


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




}