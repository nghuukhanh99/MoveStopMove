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

        enemy.MyAnimator.SetBool("IsIdle", true);
    }

    public void Execute()
    {
        if(enemy.Target != null)
        {
            enemy.ChangeState(new AttackSM());
        }
        else
        {
            Idle();
        }
    }

    public void Exit()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        
    }

    

    private void Idle()
    {
        enemy.MyAnimator.SetBool("IsIdle", true);

        idleTimer += Time.deltaTime;

        if(idleTimer >= idleDuration)
        {
            enemy.ChangeState(new PatrolSM());
        }
    }
}
