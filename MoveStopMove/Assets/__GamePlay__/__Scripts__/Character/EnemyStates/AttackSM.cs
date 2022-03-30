using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSM : IEnemyState
{
    private Enemy enemy;

    private float attackTimer;

    private float attackDuration = 0;

    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Execute()
    {
        if (enemy.nearestCharacter != null && enemy.isMoving == false)
        {
            attackTimer += Time.deltaTime;

            if (attackTimer >= 1f)
            {
                Attack();
            }
        }


    }

    public void Exit()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        
    }

    private void Attack()
    {
        if (enemy.nearestCharacter != null)
        {
            enemy.transform.LookAt(enemy.nearestCharacter.transform);
        }

        enemy.MyAnimator.SetBool(enemy.AnimIdleTag, true);

        enemy.MyAnimator.SetTrigger(enemy.AnimAttackTag);

        attackTimer += Time.deltaTime;

        if (attackTimer >= attackDuration)
        {
            enemy.ChangeState(new IdleSM());
        }
    }
}
