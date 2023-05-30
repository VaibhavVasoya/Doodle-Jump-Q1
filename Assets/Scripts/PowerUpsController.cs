using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private GameObject Propeller;
    [SerializeField] private GameObject jetPack;
    public bool heli;
    public  bool rocket;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Propeller.SetActive(false);
        jetPack.SetActive(false);
    }

    void FixedUpdate()
    {

        if (heli)
        {
            float speed = 400f;
            rb.velocity = new Vector3(rb.velocity.x, speed * Time.deltaTime);
            Invoke(nameof(Fall), 5f);
        }
        if (rocket)
        {
            float speed = 700f;
            rb.velocity = new Vector3(rb.velocity.x, speed * Time.deltaTime);
            Invoke("Fall", 5f);
        }

    }


    public void Fall()
    {

        heli = false;
        rocket = false;

        Propeller.SetActive(false);
        jetPack.SetActive(false);
        CancelInvoke();
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