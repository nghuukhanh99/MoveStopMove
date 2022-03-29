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

        enemy.attacked = false;
    }

    public void Execute()
    {
        if(enemy.Target != null && enemy.isMoving == false)
        {
            IdleAndAttack();
        }
        
    }

    public void Exit()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        
    }

    private void IdleAndAttack()
    {
        
        enemy.transform.LookAt(enemy.Target.transform);

        enemy.MyAnimator.SetBool("IsIdle", true);

        enemy.MyAnimator.SetTrigger("IsAttack");

        attackTimer += Time.deltaTime;

        if (attackTimer >= attackDuration)
        {
            enemy.Target = null;

            enemy.attacked = true;

            enemy.ChangeState(new IdleSM());
        }
    }
}
