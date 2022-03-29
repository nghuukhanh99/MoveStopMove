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

    float attackTimer;

    float attackDuration = 0f;

    public override void Start()
    {
        base.Start();
    }

    void FixedUpdate()
    {
        PlayerMovement();

        PlayerIdleAndAttack();
    }

    public void PlayerMovement()
    {
        isMoving = true;

        float xInput = joystick.Horizontal();

        float zInput = joystick.Vertical();

        Vector3 movementDirection = new Vector3(xInput, 0f, zInput);

        movementDirection.Normalize();

        transform.Translate(movementDirection * moveSpeed * Time.deltaTime, Space.World);

        if(movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed);

            animator.SetBool(AnimIdleTag, false);
        }
        else
        {
            isMoving = false;
            
            animator.SetBool(AnimIdleTag, true);
        }
    }

    public void PlayerIdleAndAttack()
    {
        if (isMoving == false && Target != null)
        {
            transform.LookAt(Target);

            animator.SetBool(AnimAttackTag, true);

            attackTimer += Time.deltaTime;

            if(attackTimer >= attackDuration)
            {
                Target = null;

                animator.SetBool(AnimIdleTag, true);
            }
        }
    }
}
