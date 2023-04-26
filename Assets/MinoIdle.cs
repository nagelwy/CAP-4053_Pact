using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinoIdle : StateMachineBehaviour
{
    public float idleTime;
    private float time;
    Rigidbody2D rb;
    Boss boss;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        time = idleTime;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb.velocity = new Vector2(0,rb.velocity.y);
        if(boss.currentHealth <= boss.MaxHealth/2)
        {
            animator.SetTrigger("Enrage");
            boss.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(1f,0.8f);
        }
        if(time <= 0)
        {
            animator.SetTrigger("IdleExit");
        }
        else
        {
            time-= Time.deltaTime;
        }

    }
    

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
