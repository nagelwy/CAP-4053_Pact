using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpIntro : StateMachineBehaviour
{
    private int random;
    Rigidbody2D rb;
    Boss boss;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();
        random = Random.Range(0,2);

        if(random == 0)
        {
            animator.SetTrigger("idle");
        }
        else
        {
            animator.SetTrigger("jump");
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }
}
