using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyShoot : StateMachineBehaviour
{
    private float timer;
    public float minTime;
    public float maxTime;
    private int random;

    public float minShoot;
    public float maxShoot;
    private float shoot;

    Transform player;
    Rigidbody2D rb;
    Boss boss;
    
    public Transform firePoint;
    public Transform enemyWeapon;
    public GameObject Projectile;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = Random.Range(minTime, maxTime);
        shoot = Random.Range(minShoot, maxShoot);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();
        random = Random.Range(0,2);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 diff = player.position - enemyWeapon.transform.position;
        
        if(shoot <= 0)
        {
            GameObject Proj = Instantiate(Projectile, firePoint.position, firePoint.transform.rotation);
            Proj.GetComponent<EnemyProjectiles>().direction = diff.normalized;
        }
        else
        {
            shoot -= Time.deltaTime;
        }
       
        if(random == 0)
        {
            if(timer <= 0)
            {
                animator.SetTrigger("chase");
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
        else
        {
            if(timer <= 0)
            {
                animator.SetTrigger("run");
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }        
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }
}
