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
    public Vector3 attackOffset;
    public float radius;
    public LayerMask Player;
    public LayerMask wall;

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
        Vector3 pos = transform.position;
        if(boss.isFlipped)
        {
            pos += transform.right * attackOffset.x;
        }
        else
        {
            pos += transform.right * -attackOffset.x;
        }
        pos += transform.up * attackOffset.y;
        Collider2D colInfo = Physics2D.OverlapCircle(pos, radius, Player);
        if(colInfo != null)
        {
            pm.BossDamage(damage, knockbackX, knockbackY, gameObject.transform.position.x >= pm.gameObject.transform.position.x);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.tag == "Wall")
        {
            gameObject.GetComponent<Animator>().SetBool("Stunned",true);
        }
    }
}
