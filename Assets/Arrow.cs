using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public bool explosive;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<Enemy>().Hit(damage,50,gameObject.GetComponent<Rigidbody2D>().velocity.x >= 0);
        }
        Destroy(gameObject);
    }
}
