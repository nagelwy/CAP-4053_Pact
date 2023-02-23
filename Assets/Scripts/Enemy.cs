using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Hit(float Damage)
    {
        Debug.Log("I was Hit!");
        currentHealth-= Damage;
        if(currentHealth <=0)
        {
            //die
            Debug.Log(gameObject.name +" is Dead!");
            Die();
        }
    }
    void Die()
    {
        //Die Animation
        gameObject.SetActive(false); // fix this to fully despawn enemy.
    }
}
