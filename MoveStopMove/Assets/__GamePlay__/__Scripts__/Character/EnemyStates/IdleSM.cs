using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleSM : IEnemyState
{
    private Enemy enemy;

    private float idleTimer;

    private float idleDuration = 2f;
    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;

        enemy.CancelDestination();
    }

    public void Execute()
    {
        enemy.FindAround();

        Idle();

        if (enemy.nearestCharacter != null)
        {
            enemy.ChangeState(new AttackSM());
        }

        idleTimer += Time.deltaTime;

        if (idleTimer >= idleDuration)
        {
            enemy.ChangeState(new PatrolSM());
        }
    }

    public void Exit()
    {
        
    }

    private void Idle()
    {
        enemy.MyAnimator.SetBool(enemy.AnimIdleTag, true);

        if(enemy.nearestCharacter != null)
        {
            enemy.transform.LookAt(enemy.nearestCharacter.transform);
        }

    }
}
