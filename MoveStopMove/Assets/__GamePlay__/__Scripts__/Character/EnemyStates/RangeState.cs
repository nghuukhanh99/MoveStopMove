using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeState : IEnemyState
{
    private Enemy enemy;
    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Execute()
    {
        if(enemy.Target != null)
        {
            
        }
    }

    public void Exit()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        
    }
}
