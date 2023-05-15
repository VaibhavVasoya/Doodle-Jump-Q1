using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBreakable : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private Animator breakAnimator;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                boxCollider.isTrigger = true;
                
                breakAnimator.SetTrigger("BreakPlatform");

                StartCoroutine(DisablePlatform());
                //transform.position = Vector2.MoveTowards(transform.position,,1f);                

            }
        }
    }


    IEnumerator DisablePlatform()
    {
        yield return new WaitForSeconds(1);


        gameObject.SetActive(false);
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
