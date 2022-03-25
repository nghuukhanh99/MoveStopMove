using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class PatrolState : StateMachineBehaviour
{
    float timer;

    int currentWaypointIndex;

    List<Transform> WayPoints = new List<Transform>();

    NavMeshAgent agent;

    string wayPoints = "WayPoints";

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0f;

        currentWaypointIndex = Random.Range(Random.Range(0, 10), WayPoints.Count);

        Transform wayPointsObject = GameObject.FindGameObjectWithTag(wayPoints).transform;

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
        WayPoints = WayPoints.Distinct().ToList();

        Transform wp = WayPoints[currentWaypointIndex];

        if (Vector3.Distance(agent.transform.position, wp.position) < 0.01f)
        {
            Play(AnimState.IsIdle, true, animator);

            agent.transform.position = wp.position;

            currentWaypointIndex = Random.Range(0, WayPoints.Count);
        }
        else
        {
            Play(AnimState.IsIdle, false, animator);

            agent.SetDestination(wp.position);

            agent.transform.LookAt(wp.position);
        }

        timer += Time.deltaTime;

        if (timer > Random.Range(2.5f, 4f))
        {
            Play(AnimState.IsIdle, true, animator);
        }
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Play(AnimState.IsIdle, true, animator);

        agent.SetDestination(agent.transform.position);
    }

    public void Play(AnimState state, bool value, Animator anim)
    {
        string animName = string.Empty;

        switch (state)
        {
            case AnimState.IsIdle:
                animName = "IsIdle";
                break;
        }

        anim.SetBool(animName, value);
    }
}