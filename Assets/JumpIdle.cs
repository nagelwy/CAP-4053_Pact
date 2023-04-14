using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpIdle : StateMachineBehaviour
{
    private float timer;
    public float minTime;
    public float maxTime;

    Rigidbody2D rb;
    Boss boss;
    jumpGroundedCheck jgc;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = Random.Range(minTime, maxTime);
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();
        jgc = animator.GetComponent<jumpGroundedCheck>();
        animator.SetBool("idle", false);
        rb.velocity = new Vector2(0,0);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       if(timer <= 0)
       {
            animator.SetBool("jump", true);
       }
       else
       {
            timer -= Time.deltaTime;
       }

       if(boss.currentHealth <= boss.MaxHealth/2)
        {
            animator.SetTrigger("enrage");
        }

        // rb.velocity = new Vector2(0,0);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }
}
