using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyRun : StateMachineBehaviour
{
    private float timer;
    public float minTime;
    public float maxTime;
    public float speed;
    private int random;

    Transform player;
    Rigidbody2D rb;
    Boss boss;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = Random.Range(minTime, maxTime);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();
        random = Random.Range(0,3);
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
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
        else if(random == 1)
        {
            if(timer <= 0)
            {
                animator.SetTrigger("attack");
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
                animator.SetTrigger("big attack");
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }

        Vector2 target = new Vector2(player.position.x, animator.transform.position.y);
        animator.transform.position = -Vector2.MoveTowards(animator.transform.position, target, speed * Time.deltaTime);
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }
}
