using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinoChargeL : StateMachineBehaviour
{
    public float accelSpeed;
    Rigidbody2D rb;
    public float maxVelocityBase;
    Boss boss;
    float maxVelocity;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb = animator.GetComponent<Rigidbody2D>();
        animator.transform.localScale = new Vector3(3,3,3);
        boss = animator.GetComponent<Boss>();
        maxVelocity = maxVelocityBase/boss.currentHealth;
        accelSpeed += 1f;
        boss.disableBox = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(-rb.velocity.x < maxVelocity)
        {
            Debug.Log("is this thing on?");
            rb.AddForce(new Vector2(-accelSpeed,0));
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
