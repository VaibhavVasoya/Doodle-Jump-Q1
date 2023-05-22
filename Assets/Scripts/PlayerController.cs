using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] float playerSpeed;
    [SerializeField] Transform player;
    [SerializeField] Transform walls;
    [SerializeField] bool facingRight = true;
    [SerializeField] private int currentScore;
    public bool inputs;


    public static PlayerController inst;


    private void Awake()
    {
        inst = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


        //For scores
        currentScore = Mathf.RoundToInt(player.position.y);
        if(currentScore > ScoreManager.instance.score)
        {
            ScoreManager.instance.score = currentScore;
        }




        //For Inputs
        if(inputs)
        {
            //AndroidInputs();
            Windowsinputs();

        }


        //for walls
        walls.transform.position = new Vector3(walls.transform.position.x, transform.position.y, walls.transform.position.z);

    }



    public void AndroidInputs()
    {
        float tilt = Input.acceleration.x;

        rb.velocity = new Vector2(tilt * playerSpeed, rb.velocity.y);

        if (tilt > 0.1 && !facingRight)
        {
            flip();
        }

        if (tilt < 0.1 && facingRight)
        {
            flip();
        }
    }

    public void Windowsinputs()
    {
        var horizontalInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(horizontalInput * playerSpeed, rb.velocity.y);

        if (horizontalInput > 0 && !facingRight)
        {
            flip();
        }

        if (horizontalInput < 0 && facingRight)
        {
            flip();
        }
    }


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


        if (collision.gameObject.CompareTag("Coin"))
        {
            AudioManager.instance.Play("Coin");
            ScoreManager.instance.coin++;
            Destroy(collision.gameObject);
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