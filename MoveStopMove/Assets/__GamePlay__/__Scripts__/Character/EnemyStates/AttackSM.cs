using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSM : IEnemyState
{
    private Enemy _Enemy;

    private float delayTime;
    public void Enter(Enemy enemy)
    {
        this._Enemy = enemy;

        if(Vector3.Distance(enemy.transform.position, enemy.nearestCharacter.transform.position) < enemy.range && enemy.timeCountdownt <= 0 && enemy.checkFirstAttack && enemy.isMoving == false)
        {
            enemy.timeCountdownt = enemy.timeStart;

            enemy.checkFirstAttack = false;
        }

        Attack();
    }

    public void Execute()
    {
        delayTime += Time.deltaTime;

        if(delayTime >= Time.time)
        {
            _Enemy.ChangeState(new IdleSM());
        }
        
        if(_Enemy.nearestCharacter == null)
        {
            _Enemy.ChangeState(new IdleSM());
        }
    }

    public void Exit()
    {
        //delayTime = 0;
    }

    private void Attack()
    {
        if (_Enemy.nearestCharacter != null)
        {
            _Enemy.transform.LookAt(_Enemy.nearestCharacter.transform);
        }

     

        _Enemy.StartCoroutine(_Enemy.Attacked());
    }
}
