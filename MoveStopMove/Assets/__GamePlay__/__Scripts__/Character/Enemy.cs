﻿using System;
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
    
    NavMeshAgent agent;

    Rigidbody rb;

    Enemy scripts;

    Collider _collider;

    int currentWaypointIndex;

    public float timeStart = 3f;

    public float timeCountdownt = 0;

    public GameObject bullet;

    public Transform PointSpawnBullet;
    private void Awake()
    {
        checkFirstAttack = true;
    }

    public override void Start()
    {
        base.Start();

        agent = GetComponent<NavMeshAgent>();

       _collider = GetComponent<Collider>();

        rb = GetComponent<Rigidbody>();

        scripts = GetComponent<Enemy>();

        currentWaypointIndex = Random.Range(Random.Range(0, 10), wayPoints.Count);

        ChangeState(new IdleSM());
    }

    public override void Update()
    {
        base.Update();

        currentState.Execute();

        Debug.Log(currentState);

        if (nearestCharacter != null && timeCountdownt <= 0)
        {
            timeCountdownt = timeStart;

            if (Vector3.Distance(transform.position, nearestCharacter.transform.position) < range)
            {
                if(checkFirstAttack && isMoving == false)
                {
                    ChangeState(new AttackSM());
                }
            }
        }

        deadFunction();
    }

    public void Attacking()
    {
        if (nearestCharacter != null)
        {
            GameObject bulletSpawn = (GameObject)Instantiate(bullet, PointSpawnBullet.position, bullet.transform.rotation);

            bulletSpawn.GetComponent<CandyBullet>().setTargetPosition(nearestCharacter.transform.position);

            bulletSpawn.GetComponent<CandyBullet>().setOwnerChar(this.gameObject.GetComponent<CharacterManager>());

            bulletSpawn.GetComponent<CandyBullet>().setOwnerPos(this.transform.position);
        }
    }

    public void deadFunction()
    {
        if(isDead == true)
        {
            _collider.enabled = false;

            rb.detectCollisions = false;

            scripts.enabled = false;

            agent.enabled = false;
        }
    }

    public void Move()
    {
        timeCountdownt -= Time.deltaTime;

        Transform wp = wayPoints[currentWaypointIndex];

        if (Vector3.Distance(agent.transform.position, wp.position) < 0.01f)
        {
            MyAnimator.SetBool(AnimIdleTag, true);

            agent.transform.position = wp.position;

            currentWaypointIndex = Random.Range(Random.Range(0, 10), wayPoints.Count);
        }
        else
        {
            MyAnimator.SetBool(AnimIdleTag, false);

            agent.SetDestination(wp.position);

            agent.transform.LookAt(wp.position);
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
  }
