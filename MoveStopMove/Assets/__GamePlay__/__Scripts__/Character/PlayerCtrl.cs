using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyJoystick;

public class PlayerCtrl : CharacterManager
{
    [SerializeField] Joystick joystick;

    [SerializeField] private float moveSpeed;
    
    [SerializeField] private float rotationSpeed;

    [SerializeField] private Animator animator;

    void FixedUpdate()
    {
        PlayerMovement();
    }

    public void PlayerMovement()
    {
        float xInput = joystick.Horizontal();

        float zInput = joystick.Vertical();

        Vector3 movementDirection = new Vector3(xInput, 0f, zInput);

        movementDirection.Normalize();

        transform.Translate(movementDirection * moveSpeed * Time.deltaTime, Space.World);

        if(movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed);

            Play(AnimState.IsIdle, false, animator);

            isMoving = true;
        }
        else
        {
            Play(AnimState.IsIdle, true, animator);

            isMoving = false;
        }

        if(isMoving == true)
        {
            if (attackCount >= maxAttackCount)
            {
                return;
            }

            attackCount += 1;
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
