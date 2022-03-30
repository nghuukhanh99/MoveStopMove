using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyJoystick;
using System;

public class PlayerCtrl : CharacterManager
{
    [SerializeField] Joystick joystick;

    [SerializeField] private float moveSpeed;
    
    [SerializeField] private float rotationSpeed;

    [SerializeField] private Animator animator;

    public GameObject bullet;

    public Transform PointSpawnBullet;

    float attackTimer;

    public float timeStart = 3f;
    public float timeCountdownt = 0;

    public static Action attacking;
    
    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
        PlayerMovement();
        if(nearestCharacter != null && timeCountdownt <= 0 )
        {
            timeCountdownt = timeStart;

            if (Vector3.Distance(transform.position, nearestCharacter.transform.position) < range)
            {
                Attacking();
            }
        }
        timeCountdownt -= Time.deltaTime;
    }
    public void Attacking()
    {
        if(nearestCharacter != null)
        {
            Vector3 directToEnemyOther = nearestCharacter.transform.position - transform.position;

            GameObject bulletSpawn = (GameObject)Instantiate(bullet, PointSpawnBullet.position, bullet.transform.rotation);

            bulletSpawn.GetComponent<CandyBullet>().setTargetPosition(nearestCharacter.transform.position);
        }

    }

    public void PlayerMovement()
    {
        isMoving = true;

        float xInput = joystick.Horizontal();

        float zInput = joystick.Vertical();

        Vector3 movementDirection = new Vector3(xInput, 0f, zInput);

        movementDirection.Normalize();

        transform.Translate(movementDirection * moveSpeed * Time.deltaTime, Space.World);

        animator.SetBool(AnimIdleTag, false);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed);

            //animator.SetBool(AnimIdleTag, false);
        }
        else
        {
            isMoving = false;

            animator.SetBool(AnimIdleTag, true);
        }
    }
    //    public void PlayerIdleAndAttack()
    //{
    //    if (isMoving == false && Target != null)
    //    {
    //        attacking?.Invoke();

    //        transform.LookAt(Target);

    //        animator.SetBool(AnimAttackTag, true);

    //        attackTimer += Time.deltaTime;

    //        if(attackTimer >= attackDuration)
    //        {
    //            Target = null;

    //            animator.SetBool(AnimIdleTag, true);
    //        }
    //    }
    //}
}
