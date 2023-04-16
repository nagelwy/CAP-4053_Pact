using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpGroundedCheck : MonoBehaviour
{
    public bool grounded;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.x < 0f)
            {
                gameObject.transform.localScale = new Vector3(2,2,1);
                
            }
            else if(rb.velocity.x> 0f)
            {
                gameObject.transform.localScale = new Vector3(-2,2,1);
            }
    }

    void OnCollisionEnter2D(Collision2D floor)
    {
        if(floor.gameObject.layer == 3)
        {
            grounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D air)
    {
        if(air.gameObject.layer == 3)
        {
            grounded = false;
        }
    }
}
