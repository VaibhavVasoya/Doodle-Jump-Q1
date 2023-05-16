using UnityEngine;
using System.Collections;

public class test: MonoBehaviour
{
    private bool jump;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pressed left click, casting ray.");
            CastRay();
        }

        if(jump)
        {
            Debug.Log("jump = true");
            ShopDoodleJumps.inst.jumpPow = 6;
        }
    }

    void CastRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (hit)
        {
            if (hit.collider.gameObject.CompareTag("bunny"))
            {
                Debug.Log("bunny selected");
                jump = true;
            }
            else
            {
                jump = false;
            }

            //Debug.Log(hit.collider.gameObject.name);
        }
    }
}