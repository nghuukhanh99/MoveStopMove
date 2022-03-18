using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : StateMachineBehaviour
{
    float timer;

    int currentWaypointIndex;

    [SerializeField] List<Transform> WayPoints = new List<Transform>();

    NavMeshAgent agent;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0f;

        currentWaypointIndex = Random.Range(Random.Range(0,10), WayPoints.Count);

        Transform wayPointsObject = GameObject.FindGameObjectWithTag("WayPoints").transform;

        foreach (Transform t in wayPointsObject)
        {
            WayPoints.Add(t);
        }

        agent = animator.GetComponent<NavMeshAgent>();

        agent.SetDestination(WayPoints[currentWaypointIndex].position);

        agent.transform.LookAt(WayPoints[currentWaypointIndex].position);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Transform wp = WayPoints[currentWaypointIndex];

        if(Vector3.Distance(agent.transform.position, wp.position) < 0.01f)
        {
            animator.SetBool("IsIdle", true);

            agent.transform.position = wp.position;

            currentWaypointIndex = Random.Range(0, WayPoints.Count);
        }
        else
        {
            animator.SetBool("IsIdle", false);

            agent.SetDestination(wp.position);

            agent.transform.LookAt(wp.position);
        }

        timer += Time.deltaTime;

        if (timer > Random.Range(2.5f, 4f))
        {
            animator.SetBool("IsIdle", true);
        }
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("IsIdle", true);

        agent.SetDestination(agent.transform.position);
    }

}
