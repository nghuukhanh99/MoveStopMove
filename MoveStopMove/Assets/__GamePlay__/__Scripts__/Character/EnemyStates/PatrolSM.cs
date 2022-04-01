using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolSM : IEnemyState
{
    private float patrolTimer;

    private float patrolDuration = 3f;

    private Enemy enemy;

    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;

    }

    public void Execute()
    {
        Patrol();

        patrolTimer += Time.deltaTime;

        enemy.FindAround();

        if (enemy.nearestCharacter != null)
        {
            if(patrolTimer >= 2f)
            {
                enemy.CancelDestination();

                enemy.MyAnimator.SetBool("IsIdle", true);

                enemy.ChangeState(new IdleSM());
            }
        }
    }

    public void Exit()
    {

    }

    private void Patrol()
    {
        enemy.MyAnimator.SetBool(enemy.AnimIdleTag, false);

        enemy.Move();

        if (patrolTimer >= patrolDuration)
        {
            enemy.ChangeState(new IdleSM());
        }
    }
}
