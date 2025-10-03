using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;

public class EnemyAIScript : MonoBehaviour
{
    public Transform target;

    public float moveSpeed = 200f;
    public float nextWaypointDistance = 3f;

    Path path;
    int curentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
        Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
                        curentWaypoint = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (path == null)
            return;


            if(curentWaypoint >= path.vectorPath.Count)
            {
                reachedEndOfPath = true;
                return;
            }
            else
            {
                reachedEndOfPath = false;
            }

        Vector2 direction = ((Vector2)path.vectorPath[curentWaypoint] - rb.position).normalized;
        Vector2 force = direction * moveSpeed * Time.deltaTime;
    }
}
