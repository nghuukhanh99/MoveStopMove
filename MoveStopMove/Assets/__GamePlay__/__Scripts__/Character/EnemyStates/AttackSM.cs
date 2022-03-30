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
        //if(enemy.Target != null && enemy.isMoving == false)
        //{
        //    attackTimer += Time.deltaTime;

        //    if(attackTimer >= 1)
        //    {
        //        IdleAndAttack();
        //    }
        //}
        
       
    }

    public void Exit()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        
    }

    //private void IdleAndAttack()
    //{
    //    enemy.transform.LookAt(enemy.Target.transform);

    //    enemy.MyAnimator.SetBool(enemy.AnimIdleTag, true);

    //    enemy.MyAnimator.SetTrigger(enemy.AnimAttackTag);

    //    attackTimer += Time.deltaTime;

    //    if (attackTimer >= attackDuration)
    //    {
    //        enemy.Target = null;

    //        enemy.ChangeState(new IdleSM());
    //    }
    //}
}
