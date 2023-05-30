using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBreakable : MonoBehaviour
{
    public GameTags gameTags;

    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private Animator breakAnimator;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
       
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null && rb.velocity.y <= 0)
            {
                boxCollider.isTrigger = true;
                AudioManager.instance.Play("Break");
                breakAnimator.SetTrigger("BreakPlatform");

                StartCoroutine(DisablePlatform());

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
            Destroy(gameObject);
            //gameObject.SetActive(false);
        }


    }


}
