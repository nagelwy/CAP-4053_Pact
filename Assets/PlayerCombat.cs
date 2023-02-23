using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator anim;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    private PlayerManager pm;
    private float attackTimer;
    void Start()
    {
        pm = gameObject.GetComponent<PlayerManager>();
    }
    void Update()
    {
        if(attackTimer <= 0)
        {
            if (Input.GetKey("left"))
            {
                Attack(false);
            }
            else if(Input.GetKey("right"))
            {
                Attack(true);
            }
        }
        else
        {
            attackTimer -= Time.deltaTime;
        }

    }
    void Attack(bool right)
    {
        gameObject.GetComponent<PlayerMovement>().attacking = true;
        attackTimer = pm.AttackTime;
        //Play attack animation
        if(right)
        {
            gameObject.transform.localScale = new Vector3(1,1,1);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(-1,1,1);
        }
        int x = Random.Range(0,3);
        if(x == 0)
        {
            anim.SetBool("Attack", true);
        }
        else if( x == 1)
        {
            anim.SetBool("Attack2", true);
        }
        else
        {
            anim.SetBool("Attack3", true);
        }

        // Detect Enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            //apply damage
            enemy.gameObject.GetComponent<Enemy>().Hit(pm.Damage);
        }
    }
    void EndAttack()
    {
        anim.SetBool("Attack", false);
        anim.SetBool("Attack2", false);
        anim.SetBool("Attack3", false);
        gameObject.GetComponent<PlayerMovement>().attacking = false;
    }
    void ScanAttack()
    {
    }
}
