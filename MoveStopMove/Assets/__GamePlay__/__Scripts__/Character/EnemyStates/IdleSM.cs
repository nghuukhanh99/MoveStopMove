using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleSM : IEnemyState
{
    private Enemy enemy;

    private float idleTimer;

    private float idleDuration = 3;
    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Execute()
    {
        if(enemy.nearestCharacter != null && enemy.isMoving == false)
        {
            enemy.ChangeState(new AttackSM());
        }

        Idle();
    }

    public void Exit()
    {
        enemy.MyAnimator.SetBool(enemy.AnimIdleTag, false);
    }

    public void OnTriggerEnter(Collider other)
    {
        
    }



    private void Idle()
    {
        enemy.isMoving = false;

        enemy.MyAnimator.SetBool(enemy.AnimIdleTag, true);

        if(enemy.nearestCharacter != null)
        {
            enemy.transform.LookAt(enemy.nearestCharacter.transform);
        }

        idleTimer += Time.deltaTime;

        if (idleTimer >= idleDuration)
        {
            enemy.ChangeState(new PatrolSM());
        }
    }
}
