using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float currentHealth;
    public float MaxHealth;
    public int Xp;
    SoundController sc;
    GameObject target;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MaxHealth;
        sc = GameObject.Find("SoundManager").GetComponent<SoundController>();
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Hit(float Damage)
    {
        StartCoroutine(ColorChange());
        Debug.Log("I was Hit!");
        currentHealth-= Damage;
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
        target.gameObject.GetComponent<PlayerManager>().xp += Xp;
        //Die Animation
        gameObject.SetActive(false); // fix this to fully despawn enemy.
    }
}
