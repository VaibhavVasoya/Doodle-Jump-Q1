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
    //[SerializeField] float jumpPower; 
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private int currentScore;
    [SerializeField] private GameObject Propeller;
    [SerializeField] private GameObject jetPack;

    bool heli;
    bool rocket;
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
        Propeller.SetActive(false);
        jetPack.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


        //for scores
        currentScore = Mathf.RoundToInt(player.position.y);
        if(currentScore > scoreManager.score)
        {
            scoreManager.score = currentScore;
        }


        //for coins



        //for Keyboard Inputs


        //for Android input
        if(inputs)
        {
            //AndroidInputs();
            Windowsinputs();

        }


        //for walls
        walls.transform.position = new Vector3(walls.transform.position.x, player.position.y, walls.transform.position.z);




        if (heli)
        {
            Vector2 direction = Vector2.up;
            float speed = 10f;
            rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));

            StartCoroutine(falling());
        }
        if (rocket)
        {
            Vector2 direction = Vector2.up;
            float speed = 19f;
            rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));

            StartCoroutine(falling());
        }

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

    IEnumerator falling()
    {
        yield return new WaitForSeconds(5);

        heli = false;
        rocket = false;

        Propeller.SetActive(false);
        jetPack.SetActive(false);


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
            scoreManager.coin++;
            Destroy(collision.gameObject);
        }
    }




    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (rb.velocity.y <= 0f && collision.gameObject.CompareTag("heli"))
        {
                heli = true;
                Debug.Log("collisionnnn");
            Destroy(collision.gameObject);
            Propeller.SetActive(true);
           
                
                
        }
        if (rb.velocity.y <= 0f && collision.gameObject.CompareTag("Rocket"))
        {
            rocket = true;
            Debug.Log("collisionnnn");
            Destroy(collision.gameObject);

            jetPack.SetActive(true);

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