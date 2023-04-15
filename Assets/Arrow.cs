using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public bool explosive;
    public float radius;
    public float damage;
    public LayerMask hittableLayer;
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
        if(explosive)
        {
            RaycastHit2D[] enemiesHit = Physics2D.CircleCastAll(gameObject.transform.position,radius,new Vector2(0,0),0,hittableLayer);
            foreach(RaycastHit2D ray in enemiesHit)
            {
                if(ray.transform.gameObject.tag == "Enemy")
            {
                ray.transform.gameObject.GetComponent<Enemy>().Hit(damage,50,gameObject.transform.position.x < ray.transform.position.x);
            }
            else if(ray.transform.gameObject.tag == "Boss")
            {
                ray.transform.gameObject.GetComponent<Boss>().Hit(damage);
            }
            }
        }
        else
        {
            if(col.gameObject.tag == "Enemy")
            {
                col.gameObject.GetComponent<Enemy>().Hit(damage,50,gameObject.GetComponent<Rigidbody2D>().velocity.x >= 0);
            }
        }
        Destroy(gameObject);
    }
}
