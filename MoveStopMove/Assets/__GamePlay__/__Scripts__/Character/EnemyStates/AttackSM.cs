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

        if(enemy.nearestCharacter != null)
        {
            enemy.checkFirstAttack = false;

            Attack();

            enemy.WeaponHand.SetActive(false);
        }
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
        delayTime = 0;
    }

    private void Attack()
    {
        if (_Enemy.nearestCharacter != null)
        {
            _Enemy.transform.LookAt(_Enemy.nearestCharacter.transform);
        }
        _Enemy.Attacking();
    }
}
