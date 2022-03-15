using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : CharacterManager
{
    [SerializeField] private string enemyName;

    [SerializeField] private float moveSpeed;

    public Transform[] waypoints;

    private int currentWaypointIndex;

    private float waitTime;

    private float waitCounter = 0f;

    private bool waiting = false;

    NavMeshAgent agent;
    // Start is called before the first frame update

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        waitTime = Random.Range(1.5f, 3f);

        currentWaypointIndex = Random.Range(0, waypoints.Length);
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (waiting)
        {
            waitCounter += Time.deltaTime;

            if(waitCounter < waitTime)
            {
                return;
            }

            waiting = false;
        }

        Transform wp = waypoints[currentWaypointIndex];

        if(Vector3.Distance(transform.position, wp.position) < 0.01f)
        {
            GetComponent<Animator>().SetBool("IsIdle", true);

            transform.position = wp.position;

            waitCounter = 0f;

            waiting = true;

            ////currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;

            currentWaypointIndex = Random.Range(0, waypoints.Length);
        }
        else
        {
            GetComponent<Animator>().SetBool("IsIdle", false);

            transform.position = Vector3.MoveTowards(transform.position, wp.position, moveSpeed * Time.deltaTime);

            transform.LookAt(wp.position);
        }
    }
    
    
}
