using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpGroundedCheck : MonoBehaviour
{
    public bool grounded;
    public bool falling;
    public bool x;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!grounded)
        {
            if(!x)
            {
                x = true;
                StartCoroutine(delay());
            }
        }
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(0.5f);

        falling = true;
        x = false;
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
