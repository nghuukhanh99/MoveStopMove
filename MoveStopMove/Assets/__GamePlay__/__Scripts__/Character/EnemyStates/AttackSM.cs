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
        if (enemy.checkFirstAttack && enemy.nearestCharacter != null)
        {
            enemy.checkFirstAttack = false;

            Attack();
        }
    }

    public void Exit()
    {
        enemy.MyAnimator.ResetTrigger(enemy.AnimAttackTag);
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

        enemy.Attacking();

        enemy.MyAnimator.SetTrigger(enemy.AnimAttackTag);

        attackTimer += Time.deltaTime;

        if(attackTimer >= attackDuration)
        {
            enemy.ChangeState(new IdleSM());
        }
        
    }
}
