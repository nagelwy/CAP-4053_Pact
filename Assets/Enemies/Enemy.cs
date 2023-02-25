using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;



public class Enemy : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public int enemyxp;
    private Rigidbody2D rb;
    private SoundController sc;
    [Header("Pathfinding")]
    public Transform target;
    public float activateDistance = 50f;
    public float pathUpdateSeconds = 2f;

    [Header("Physics")]
    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    public float jumpNodeHeightRequirement = 0.8f;
    public float jumpModifier = 0.3f;
    public float jumpCheckOffset = 0.1f;

    [Header("Custom Behavior")]
    public bool followEnable = true;
    public bool jumpEnable = false;
    public bool directionLookEnabled = true;

    // Path variables for finding player and waypoints
    private Path path;
    private int currentWaypoint = 0;
    // private bool pathIsEnded = false;
    bool isGrounded = false;
    Seeker seeker;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        rb = gameObject.GetComponent<Rigidbody2D>();
        sc = GameObject.Find("SoundManager").GetComponent<SoundController>();

        seeker = GetComponent<Seeker>();
        InvokeRepeating("UpdatePath", 0f, pathUpdateSeconds);

        if(target == null)
        {
            Debug.LogError("Select the player");
            return;
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(TargetInDistance() /*&& followEnabled */)
        {
            PathFollow();
        }
    }
     private void OnPathCompete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    private void UpdatePath()
    {
        if(/*followEnabled && */TargetInDistance() && seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathCompete);
        }
    }

    private void PathFollow()
    {
        if(path == null)
        {
            return;
        }

        //end of path
        if(currentWaypoint >= path.vectorPath.Count)
        {
            return;
        }

        // check if colliding
        Vector3 startOffset = transform.position - new Vector3(0f, GetComponent<Collider2D>().bounds.extents.y + jumpCheckOffset);
        isGrounded = Physics2D.Raycast(startOffset, -Vector3.up, 0.05f);

        //directions
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        // Jump
        if(jumpEnable && isGrounded)
        {
            if(direction.y > jumpNodeHeightRequirement)
            {
                rb.AddForce(Vector2.up * speed * jumpModifier);
            }
        }

        // Movement
        rb.AddForce(force);

        // Next point
        float distance = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);

        if(distance < nextWaypointDistance)
        {
            currentWaypoint++;
            return;
        }

        // Graphics
        if(directionLookEnabled)
        {
            if(rb.velocity.x > 0.05f)
            {
                transform.localScale = new Vector3(-1f * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else if(rb.velocity.x < -0.05f)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }
    }

    private bool TargetInDistance()
    {
        return Vector3.Distance(transform.position, target.transform.position) < activateDistance;
    }
    public void Hit(float Damage, float knockback, bool right)
    {
        Debug.Log("I was Hit!");
        currentHealth-= Damage;
        StartCoroutine(ColorChange());
        if(right)
        {
            rb.AddForce(new Vector2(knockback,knockback/2));
        }
        else
        {
            rb.AddForce(new Vector2(-knockback,knockback/2));
            
        }
        if(currentHealth <=0)
        {
            //die
            Debug.Log(gameObject.name +" is Dead!");
            Die();
        }
    }
    private IEnumerator ColorChange()
    {
        sc.PlaySound(1);
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
    void Die()
    {
        target.gameObject.GetComponent<PlayerManager>().xp += enemyxp;
        //Die Animation
        gameObject.SetActive(false); // fix this to fully despawn enemy.
    }
}
