using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;
using System.Linq;

public class Enemy : CharacterManager
{
    [SerializeField] private string enemyName;

    private IEnemyState currentState;

    public List<Transform> wayPoints = new List<Transform>();

    public List<GameObject> TargetList = new List<GameObject>();
    
    NavMeshAgent agent;

    int currentWaypointIndex;

    public Transform Target { get; set; }

    public override void Start()
    {
        attackCount += 1;
        
        base.Start();

        agent = GetComponent<NavMeshAgent>();

        currentWaypointIndex = Random.Range(Random.Range(0, 10), wayPoints.Count);

        ChangeState(new IdleSM());
    }

    public override void Update()
    {
        base.Update();

        if(isMoving == true && attacked == false)
        {
            FindAround();


        }
        

        currentState.Execute();

    }

    void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(other);
    }
    
    public void Move()
    {
        Transform wp = wayPoints[currentWaypointIndex];

        if (Vector3.Distance(agent.transform.position, wp.position) < 0.01f)
        {
            Play(AnimState.IsIdle, true, MyAnimator);

            agent.transform.position = wp.position;

            currentWaypointIndex = Random.Range(Random.Range(0, 10), wayPoints.Count);
        }
        else
        {
            Play(AnimState.IsIdle, false, MyAnimator);

            agent.SetDestination(wp.position);

            agent.transform.LookAt(wp.position);
        }

        if (attackCount >= maxAttackCount)
        {
            return;
        }

        attackCount += 1;
    }

    public void FindAround()
    {
        float shortestDistance = Mathf.Infinity;

        GameObject nearestCharacter = null;

        for(int i = 0; i < this.TargetList.Count; i++)
        {
            float distanceToOtherCharacter = Vector3.Distance(transform.position, this.TargetList[i].transform.position);

            if(distanceToOtherCharacter < shortestDistance)
            {
                shortestDistance = distanceToOtherCharacter;

                nearestCharacter = this.TargetList[i];
            }
        }

        if (nearestCharacter != null && shortestDistance < range)
        {
            Target = nearestCharacter.transform;

            haveTarget = true;
        }
        else
        {
            Target = null;

            haveTarget = false;
        }
    }

    public void CancelDestination()
    {
        currentWaypointIndex = Random.Range(Random.Range(0, 10), wayPoints.Count);

        agent.SetDestination(agent.transform.position);
    }

    public void ChangeState(IEnemyState newState)
    {
        if(currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;

        currentState.Enter(this);
    }



    public void Play(AnimState state, bool value, Animator anim)
    {
        string animName = string.Empty;

        switch (state)
        {
            case AnimState.IsIdle:
                animName = "IsIdle";
                break;
            case AnimState.IsAttack:
                animName = "IsAttack";
                break;
            case AnimState.IsDead:
                animName = "IsDead";
                break;
            case AnimState.IsDance:
                animName = "IsDance";
                break;
            case AnimState.IsWin:
                animName = "IsWin";
                break;
            case AnimState.IsUlti:
                animName = "IsUlti";
                break;
        }

        anim.SetBool(animName, value);
    }

    
  }
