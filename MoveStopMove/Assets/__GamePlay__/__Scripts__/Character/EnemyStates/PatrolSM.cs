﻿using System.Collections;
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

        enemy.MyAnimator.SetBool(enemy.AnimIdleTag, false);
    }

    public void Execute()
    {
        
        Patrol();

        if (enemy.nearestCharacter != null)
        {
            patrolTimer += Time.deltaTime;

            if (patrolTimer >= 1f)
            {
                enemy.isMoving = false;

                enemy.CancelDestination();

                enemy.transform.LookAt(enemy.nearestCharacter.transform);

                enemy.ChangeState(new IdleSM());
            }
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

        enemy.Move();

        patrolTimer += Time.deltaTime;

        if (patrolTimer >= patrolDuration)
        {
            enemy.CancelDestination();

            if(enemy.nearestCharacter != null)
            {
                enemy.transform.LookAt(enemy.nearestCharacter.transform);
            }

            enemy.ChangeState(new IdleSM());
        }
    }
}
