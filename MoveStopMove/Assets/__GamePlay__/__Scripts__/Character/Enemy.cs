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
    
    NavMeshAgent agent;

    Rigidbody rb;

    Enemy scripts;

    Collider _collider;

    int currentWaypointIndex;

    public float timeStart = 3f;

    public float timeCountdownt = 0;

    public GameObject bullet;

    public bool needPatrolToAttack;

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
        if (GameManager.Instance.isGameActive == true)
        {
            currentState.Execute();

            if (nearestCharacter != null)
            {
                if (Vector3.Distance(transform.position, nearestCharacter.transform.position) < range && timeCountdownt <= 0 && checkFirstAttack && isMoving == false)
                {
                    timeCountdownt = timeStart;

                }
            }
            deadFunction();
        }

        timeCountdownt -= Time.deltaTime;

        timeCountdownt = Mathf.Clamp(timeCountdownt, 0, Mathf.Infinity);

        base.Update();

        if (timeCountdownt <= 0)
        {
            showWeapon();
        }
    }

    public void Attacking()
    {
        MyAnimator.SetTrigger("IsAttack");

        GameObject poolingBullet = null;

        if (bullet.name == "Hammer Bullet")
        {
            poolingBullet = PoolBullet.Instance.GetPooledBullet();
        }
        else if (bullet.name == "Candy Bullet")
        {
            poolingBullet = PoolCandyBullet.Instance.GetPooledBullet();
        }
        else if (bullet.name == "Knife Bullet")
        {
            poolingBullet = PoolKnife.Instance.GetPooledBullet();
        }

        poolingBullet.transform.position = PointSpawnBullet.position;

        poolingBullet.transform.rotation = poolingBullet.transform.rotation;

        poolingBullet.SetActive(true);

        poolingBullet.GetComponent<BulletsWeapon>().setTargetPosition(nearestCharacter.transform.position);

        poolingBullet.GetComponent<BulletsWeapon>().setOwnerChar(this.gameObject.GetComponent<CharacterManager>());

        poolingBullet.GetComponent<BulletsWeapon>().setOwnerPos(this.transform.position);

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
