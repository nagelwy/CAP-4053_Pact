using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class flyingEnemy : MonoBehaviour
{
    public float health;

    [Header("Pathfinding")]
    public Transform target;
    public float activateDistance = 50f;
    public float pathUpdateSeconds = 2f;

    [Header("Physics")]
    public float speed = 300f;
    public float nextWaypointDistance = 3f;

    [Header("Custom Behavior")]
    public bool followEnable = true;
    public bool directionLookEnabled = true;

    // Path variables for finding player and waypoints
    private Path path;
    private int currentWaypoint = 0;
    private bool pathIsEnded = false;
    Seeker seeker;
    Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        
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

        //directions
        Vector3 direction = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        direction *= speed * Time.fixedDeltaTime;

        // Movement
        rb.AddForce(direction);

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

    public void Hit(float Damage)
    {
        Debug.Log("I was Hit!");
        health -= Damage;
    }
}
