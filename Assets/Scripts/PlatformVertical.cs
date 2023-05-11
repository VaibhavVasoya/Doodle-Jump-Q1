using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformVertical : MonoBehaviour
{

    [SerializeField] private bool movingUp = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (movingUp == true)
        {
           

            transform.Translate(Vector2.up * 2f * Time.deltaTime);
            if (transform.position.y >= transform.position.y + 3f)
            {
                Debug.Log("hey");
                movingUp = false;
            }
        }
        else
        {
            transform.Translate(Vector2.down * 2f * Time.deltaTime);
            if(transform.position.y <= transform.position.y - 3f)
            {
                movingUp = true;
            }
        }
    }


            
}
