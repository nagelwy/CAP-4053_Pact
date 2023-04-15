using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float currentHealth;
    public float MaxHealth;
    public int Xp;
    public int Gold;
    SoundController sc;
    public int damage;
    public int knockback;
    public bool isFlipped = false;
    GameObject target;
    public bool disableBox;


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
        if(currentHealth <= 0)
        {
            Die();
        }
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
        target.gameObject.GetComponent<PlayerManager>().gold += Gold;
        //Die Animation
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(!disableBox)
        {
            if(collision.gameObject.tag == "Player")
            target.gameObject.GetComponent<PlayerManager>().TakeDamage(damage, knockback, gameObject.transform.position.x >= target.gameObject.GetComponent<PlayerManager>().gameObject.transform.position.x);
        }
    }
    public void onEnter()
    {
        gameObject.GetComponent<Animator>().SetTrigger("OnAwake");
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if(transform.position.x > target.transform.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f,180f,0f);
            isFlipped = false;
        }
        else if(transform.position.x < target.transform.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f,180f,0f);
            isFlipped = true;
        }
    }
}
