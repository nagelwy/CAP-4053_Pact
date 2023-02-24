using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    private Rigidbody2D rb;
    private SoundController sc;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        rb = gameObject.GetComponent<Rigidbody2D>();
        sc = GameObject.Find("SoundManager").GetComponent<SoundController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Hit(float Damage, float knockback, bool right)
    {
        Debug.Log("I was Hit!");
        currentHealth-= Damage;
        StartCoroutine(ColorChange());
        if(right)
        {
            rb.AddForce(new Vector2(knockback,knockback/3));
        }
        else
        {
            rb.AddForce(new Vector2(-knockback,knockback/3));
            
        }
        if(currentHealth <=0)
        {
            //die
            Debug.Log(gameObject.name +" is Dead!");
            Die();
        }
    }
    private IEnumerator ColorChange()
    {
        sc.PlaySound(1);
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
    void Die()
    {
        //Die Animation
        gameObject.SetActive(false); // fix this to fully despawn enemy.
    }
}
