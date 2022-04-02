using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSM : IEnemyState
{
    private Enemy enemy;

    private float delayTime;
    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;

        if(enemy.nearestCharacter != null)
        {
            enemy.checkFirstAttack = false;

            Attack();

            
            enemy.HideWeapon();
        }
    }

    public void Execute()
    {
        delayTime += Time.deltaTime;

        if(delayTime >= Time.time)
        {
            enemy.ChangeState(new IdleSM());
        }
        
        if(enemy.nearestCharacter == null)
        {
            enemy.ChangeState(new IdleSM());
        }
    }

    public void Exit()
    {
        delayTime = 0;
    }

    private void Attack()
    {
        if (enemy.nearestCharacter != null)
        {
            enemy.transform.LookAt(enemy.nearestCharacter.transform);
        }

        enemy.Attacking();
    }
}
