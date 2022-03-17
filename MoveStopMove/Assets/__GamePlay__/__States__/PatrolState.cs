using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{
    private static PatrolState instance;
    public static PatrolState Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<PatrolState>();
            }

            return instance;
        }
    }

    public IdleState idleState;

    public bool canSeeTheCharacter;

    public Animator anim;

    [SerializeField] private float moveSpeed;

    public Transform[] waypoints;

    private int currentWaypointIndex;

    private float waitTime;

    private float waitCounter = 0f;

    private bool waiting = false;

    public GameObject Character;

    private void Start()
    {
        waitTime = Random.Range(1.5f, 3f);

        currentWaypointIndex = Random.Range(0, waypoints.Length);
    }

    public override State RunCurrentState()
    {
        Patrol();

        ExitState();

        if (canSeeTheCharacter)
        {
            return idleState;
        }
        else
        {
            return this;
        }
    }

    public void ExitState()
    {
        if (AttackState.Instance.Attacked == true && IdleState.Instance.isInAttackRange == true && canSeeTheCharacter == true)
        {
            AttackState.Instance.Attacked = false;

            IdleState.Instance.isInAttackRange = false;

            Character.GetComponent<Animator>().SetBool("IsIdle", false);

            Character.GetComponent<Animator>().SetBool("IsAttack", false);

            canSeeTheCharacter = false;
        }
    }

    void Patrol()
    {
        if (waiting)
        {
            waitCounter += Time.deltaTime;

            if (waitCounter < waitTime)
            {
                return;
            }

            waiting = false;
        }

        Transform wp = waypoints[currentWaypointIndex];

        if (Vector3.Distance(Character.transform.position, wp.position) < 0.01f)
        {
            Character.GetComponent<Animator>().SetBool("IsIdle", true);

            Character.transform.position = wp.position;

            waitCounter = 0f;

            waiting = true;

            currentWaypointIndex = Random.Range(0, waypoints.Length);
        }
        else
        {
            Character.GetComponent<Animator>().SetBool("IsIdle", false);

            Character.transform.position = Vector3.MoveTowards(Character.transform.position, wp.position, moveSpeed * Time.deltaTime);

            Character.transform.LookAt(wp.position);
        }
    }
}
