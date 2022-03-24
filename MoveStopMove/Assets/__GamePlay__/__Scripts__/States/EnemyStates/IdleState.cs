using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : StateMachineBehaviour
{
    float timer;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0f;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;

        if(timer > 3f)
        {
            Play(AnimState.IsIdle, false, animator);
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
}
