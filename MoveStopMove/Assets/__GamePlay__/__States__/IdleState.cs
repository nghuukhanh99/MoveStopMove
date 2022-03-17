using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    private static IdleState instance;
    public static IdleState Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<IdleState>();
            }

            return instance;
        }
    }

    public AttackState attackState;

    public GameObject Character;

    public bool isInAttackRange;

    public Animator anim;
    public override State RunCurrentState()
    {
        Character.GetComponent<Animator>().SetBool("IsIdle", true);

        if (isInAttackRange)
        {
            return attackState;
        }
        else
        {
            return this;
        }
    }
}
