using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpPower;
    private bool facingRight;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform HitBox;
    [SerializeField] private LayerMask defaultLayer;
    private SpriteRenderer f;
    private Animator anim;
    private int dashing;
    private bool canDash = true;
    private bool isDashing;
    private int rdashCounter = 0;
    private float rdashTimer;
    private int ldashCounter = 0;
    private float ldashTimer;
    private float AttackTimer = 0;
    public float AttackDelay;
    public float doubleTapTime = 0.3f;
    public float dashTime;
    public float dashingPower;
    public float dashCD;
    public float gravity;
    // Start is called before the first frame update
    void Start()
    {
        f = gameObject.GetComponent<SpriteRenderer>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDashing)
        {
            return;
        }
        //ATTACKING

        if(Input.GetAxis("Attack")!=0 && AttackTimer <= 0)
        {
            anim.SetTrigger("Attack");
        }

        if(AttackTimer > 0)
        {
            AttackTimer -= Time.deltaTime;
        }


        //LEFT RIGHT MOVEMENT
        float x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(x*speed, rb.velocity.y);
        flip(x);

        if(x != 0 )
        {
            anim.SetBool("Walking",true);
        }
        else
        {
            anim.SetBool("Walking",false);
        }

        //JUMPING
        if(Input.GetAxis("Jump")!= 0 && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }

        // DASHING
        if(canDash)
        {
            if(Input.GetKeyDown("d"))
            {
                if(rdashCounter == 1)
                {
                    Debug.Log("right");
                    StartCoroutine(dash(true));
                }
            }
            if(Input.GetKeyUp("d"))
            {
                rdashTimer = dashTime;
                rdashCounter++;
            }

            if(Input.GetKeyDown("a"))
            {
                if(ldashCounter == 1)
                {
                    Debug.Log("left");
                    StartCoroutine(dash(false));
                }
            }
            if(Input.GetKeyUp("a"))
            {
                ldashTimer = dashTime;
                ldashCounter++;
            }


            if(rdashTimer > 0)
            {
                rdashTimer -= Time.deltaTime;
            }
            else
            {
                rdashCounter = 0;
                rdashTimer = 0;
            }
            if(ldashTimer > 0)
            {
                ldashTimer -= Time.deltaTime;
            }
            else
            {
                ldashCounter = 0;
                ldashTimer = 0;
            }
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position,0.2f,groundLayer);
    }
    private void flip(float x)
    {
        if(x < 0f)
        {
            facingRight = false;
            gameObject.transform.localScale = new Vector3(-1,1,1);
            
        }
        else if( x > 0f)
        {
            facingRight = true;
            gameObject.transform.localScale = new Vector3(1,1,1);
        }
    }
    private IEnumerator dash(bool right)
    {
        canDash = false;
        isDashing = true;
        rb.gravityScale = 0f;
        
        if(facingRight && !right)
        {
            rb.velocity = new Vector2(transform.localScale.x * -dashingPower, 0f);
        }
        else if(!facingRight && right)
        {
            rb.velocity = new Vector2(transform.localScale.x * -dashingPower, 0f);
        }
        else
        {
           rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        }

        yield return new WaitForSeconds(dashTime);
        rb.gravityScale = gravity;
        isDashing = false;
        yield return new WaitForSeconds(dashCD);
        canDash = true;
    }
    void EndAttack()
    {
        anim.SetBool("Attack", false);
        AttackTimer = AttackDelay;
    }
    void ScanAttack()
    {
       List<Collider2D> ColList;
       bool work = Physics2D.OverlapCircle(HitBox.position,0.2f,defaultLayer);
       //Debug.Log(ColList);
    }
}
