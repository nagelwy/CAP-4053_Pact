using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeCollide : MonoBehaviour
{
    public Boss boss;
    public int damageDiv;
    public float knockbackY;
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(boss.disableBox)
        {
            if(collision.gameObject.tag == "Player")
            {
                int damage = (int)Mathf.Abs(gameObject.GetComponent<Rigidbody2D>().velocity.x/damageDiv);
                if(1 >= damage)
                {
                    damage = 1;
                }
                collision.gameObject.GetComponent<PlayerManager>().BossDamage(damage, 0, knockbackY, gameObject.transform.position.x >= collision.gameObject.GetComponent<PlayerManager>().gameObject.transform.position.x);
            }
        }
    }
}
