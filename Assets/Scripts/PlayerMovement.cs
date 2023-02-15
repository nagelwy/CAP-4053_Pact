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
    public int comboNum = 0;
    public bool attackHeld;
    public float AttackDelay;
    public float doubleTapTime = 0.3f;
    public float dashTime;
    public float dashingPower;
    public float dashCD;
    public float gravity;
    private bool hasDoubleJump;
    private bool isJumping;
    private SoundController sc;
    // Start is called before the first frame update
    void Start()
    {
        f = gameObject.GetComponent<SpriteRenderer>();
        anim = gameObject.GetComponent<Animator>();
        sc = GameObject.Find("SoundManager").GetComponent<SoundController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDashing)
        {
            return;
        }
        //ATTACKING

        if (Input.GetAxis("Attack") != 0 && AttackTimer <= 0 && comboNum == 0)
        {
            anim.SetBool("Attack",true);
            attackHeld = true;
            anim.SetBool("AttackHeld", true);
            AttackTimer = AttackDelay;

        }
        else if (Input.GetAxis("Attack") != 0 && AttackTimer <= 0 && comboNum == 1)
        {
            anim.SetBool("Attack2",true);
        }
        else if (Input.GetAxis("Attack") != 0 && AttackTimer <= 0 && comboNum == 2)
        {
            anim.SetBool("Attack3",true);
        }

        if (AttackTimer > 0)
        {
            AttackTimer -= Time.deltaTime;
        }
        if(Input.GetAxis("Attack") == 0)
        {
            comboNum = 0;
            attackHeld = false;
            anim.SetBool("AttackHeld", false);
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

        bool grounded = IsGrounded();
        if (Input.GetAxis("Jump")!= 0 && grounded && !isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            sc.PlaySound(0);
            isJumping = true;
        }

        if(Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }

        if(!grounded && hasDoubleJump && !isJumping && Input.GetAxis("Jump") != 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            sc.PlaySound(0);
            hasDoubleJump = false;
        }
        if(grounded)
        {
            hasDoubleJump = true;
        }

        // DASHING
        if (canDash)
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
        return Physics2D.OverlapCircle(groundCheck.position,0.3f,groundLayer);
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
        sc.PlaySound(1);

        yield return new WaitForSeconds(dashTime);
        rb.gravityScale = gravity;
        isDashing = false;
        yield return new WaitForSeconds(dashCD);
        canDash = true;
    }
    void EndAttack()
    {
        anim.SetBool("Attack", false);
        anim.SetBool("Attack2", false);
        anim.SetBool("Attack3", false);
        AttackTimer = AttackDelay;
        comboNum++;
        if(comboNum == 3)
        {
            comboNum = 0;
        }
    }
    void ScanAttack()
    {
       List<Collider2D> ColList;
       bool work = Physics2D.OverlapCircle(HitBox.position,0.2f,defaultLayer);
       //Debug.Log(ColList);
    }
}
