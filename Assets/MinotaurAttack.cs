using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurAttack : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerManager pm;
    Boss boss;
    public int damage;
    public float knockbackX;
    public float knockbackY;
    public GameObject attackPoint;
    public float radius;
    public LayerMask Player;

    void Start()
    {
        pm = GameObject.Find("Player").GetComponent<PlayerManager>();
        boss = gameObject.GetComponent<Boss>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Attack()
    {
        
        Collider2D[] colInfo = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, Player);
        if(colInfo != null)
        {
            pm.BossDamage(damage, knockbackX, knockbackY, gameObject.transform.position.x >= pm.gameObject.transform.position.x);
        }
    }
}
