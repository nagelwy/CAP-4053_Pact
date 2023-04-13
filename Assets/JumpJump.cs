using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpJump : StateMachineBehaviour
{
    private float timer;
    public float minTime;
    public float maxTime;
    public float speed;
    public bool hasJumped;

    Transform player;
    Rigidbody2D rb;
    Boss boss;
    jumpGroundedCheck jgc;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = Random.Range(minTime, maxTime);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();
        jgc = animator.GetComponent<jumpGroundedCheck>();
        animator.SetBool("jump", false);
        rb.AddForce(new Vector2((player.position.x - boss.transform.position.x) * speed, 5000));
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {   
        if((rb.velocity.y > 2) && !jgc.grounded)
        {
            hasJumped = true;
        }
        
        if(jgc.grounded && hasJumped)
        {
            hasJumped = false;
            animator.SetBool("idle", true);
        }

        if(boss.currentHealth <= boss.MaxHealth/2)
        {
            animator.SetTrigger("enrage");
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }
}
