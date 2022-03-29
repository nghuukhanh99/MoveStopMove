using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : CharacterManager
{
    [SerializeField] private string enemyName;

     Animator animator;

    public override void Start()
    {
        ChangeState(new StateIdle());
    }

    internal virtual void Run()
    {
        //time > 5s
        ChangeState(new StateIdle());
    }

    public override void Update()
    {
        if (currentState != null)
        {
            currentState.OnExecute(this);
        }
    }

    public void Play(AnimState state, bool value, Animator anim)
    {
        string animName = string.Empty;

        switch (state)
        {
            case AnimState.IsIdle:
                animName = "IsIdle";
                break;
            case AnimState.IsAttack:
                animName = "IsAttack";
                break;
            case AnimState.IsDead:
                animName = "IsDead";
                break;
            case AnimState.IsDance:
                animName = "IsDance";
                break;
            case AnimState.IsWin:
                animName = "IsWin";
                break;
            case AnimState.IsUlti:
                animName = "IsUlti";
                break;
        }

        anim.SetBool(animName, value);
    }


    private IState currentState;

    public void ChangeState(IState state)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }

        currentState = state;

        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }
  }
