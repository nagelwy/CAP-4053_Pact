using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectiles : MonoBehaviour
{
    public float projectileSpeed;
    public float lifeTime;
    public int damage;
    // public int knockBack;
    public Vector3 direction;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(direction * projectileSpeed);
    }

    // Update is called once per frame
    void fixedUpdate()
    {
        transform.Translate(direction * projectileSpeed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("OnCollisionEnter2D");

        if(col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerManager>().TakeDamage(damage, 0, direction.x >= 0);
        }
        Destroy(gameObject);
    }
}
