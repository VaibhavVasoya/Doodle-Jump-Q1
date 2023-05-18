using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformHorizontal : MonoBehaviour
{

    [SerializeField] private float jumpForce;
    [SerializeField] bool movingleft = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (movingleft == true)
        {
            transform.Translate(Vector3.left * 2f * Time.deltaTime);
            if (transform.position.x <= -3)
            {
                Debug.Log("lessthan4");
                movingleft = false;

            }
        }

        else
        {
            transform.Translate(Vector3.right * 2f * Time.deltaTime);
            if(transform.position.x >= 3)
            {
                movingleft = true;
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



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DownWall"))
        {
            Debug.Log("triggered");
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }


}
