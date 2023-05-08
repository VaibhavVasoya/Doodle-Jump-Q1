using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipedestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //public void OnCollisionEnter2D(Collision2D collision)
    //{
    //    //Debug.Log("collided");
    //    if (collision.gameObject.CompareTag("DownWall"))
    //    {
    //        Debug.Log("Destroyed");
    //        Destroy(collision.gameObject);
    //    }
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DownWall"))
        {
            Debug.Log("triggered");
            Destroy(gameObject);
        }
    }
}
