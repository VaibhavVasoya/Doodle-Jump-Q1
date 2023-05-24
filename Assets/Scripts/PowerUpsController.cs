using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsController : MonoBehaviour
{
    private Rigidbody2D rb;
    //public BoxCollider2D boxCollider2D;
    [SerializeField] private GameObject Propeller;
    [SerializeField] private GameObject jetPack;
    bool heli;
    bool rocket;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //boxCollider2D = GetComponent<BoxCollider2D>();

        Propeller.SetActive(false);
        jetPack.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (heli)
        {
            float speed = 400f;
            rb.velocity = new Vector3(rb.velocity.x, speed * Time.deltaTime);
            //boxCollider2D.enabled = false;            
            StartCoroutine(falling());
        }
        if (rocket)
        {
            float speed = 700f;
            rb.velocity = new Vector3(rb.velocity.x, speed * Time.deltaTime);
            //boxCollider2D.enabled = false;
            StartCoroutine(falling());
        }

    }


  
    IEnumerator falling()
    {
        yield return new WaitForSeconds(5);

        heli = false;
        rocket = false;

        //boxCollider2D.enabled = true;
        Propeller.SetActive(false);
        jetPack.SetActive(false);


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (rb.velocity.y <= 0f && collision.gameObject.CompareTag("heli"))
        {
            heli = true;
            AudioManager.instance.Play("Propeller");
            Debug.Log("collisionnnn");
            Destroy(collision.gameObject);
            Propeller.SetActive(true);
        }

        if (rb.velocity.y <= 0f && collision.gameObject.CompareTag("Rocket"))
        {
            rocket = true;
            AudioManager.instance.Play("JetPack");
            Debug.Log("collisionnnn");
            Destroy(collision.gameObject);
            jetPack.SetActive(true);

        }
    }

}