using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolSM : IEnemyState
{
    private float patrolTimer;

    private float patrolDuration = 3;

    private Enemy enemy;

    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;

        enemy.MyAnimator.SetBool("IsIdle", false);
    }

    public void Execute()
    {
        if (enemy.Target != null)
        {
            enemy.isMoving = false;

            enemy.CancelDestination();

            enemy.ChangeState(new IdleSM());
        }

        if(enemy.Target == null)
        {
            Patrol();
        }
        
    }

    public void Exit()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        
    }

    private void Patrol()
    {
        enemy.isMoving = true;

        enemy.attacked = false;
        
        enemy.Move();

        patrolTimer += Time.deltaTime;

        if (patrolTimer >= patrolDuration)
        {
            enemy.CancelDestination();

            enemy.transform.LookAt(enemy.Target);
           
            enemy.ChangeState(new IdleSM());
        }
    }
}
