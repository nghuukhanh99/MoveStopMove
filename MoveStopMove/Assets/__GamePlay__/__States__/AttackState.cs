using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    private static AttackState instance;
    public static AttackState Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<AttackState>();
            }

            return instance;
        }
    }

    public Animator anim;

    public PatrolState patrolState;

    public bool Attacked;

    public GameObject Character;
    public override State RunCurrentState()
    {
        Character.GetComponent<Animator>().SetBool("IsAttack", true);

        if (Attacked)
        {
            return patrolState;
        }
        else
        {
            return this;
        }
    }
}
