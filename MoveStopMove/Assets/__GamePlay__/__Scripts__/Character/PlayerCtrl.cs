using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PlayerCtrl : CharacterManager
{
    [SerializeField] FloatingJoystick joystick;

    [SerializeField] private float moveSpeed;
    
    [SerializeField] private float rotationSpeed;

    [SerializeField] private Animator animator;

    public GameObject bullet;

    public float timeStart = 1.5f;

    public float timeCountdownt = 0;

    public Vector3 mousePos;

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
        
        if(isDead == false)
        {
            PlayerMovement();
        }

        if(nearestCharacter != null)
        {
            if (Vector3.Distance(transform.position, nearestCharacter.transform.position) < range && timeCountdownt <= 0 && checkFirstAttack && isMoving == false)
            {
                    timeCountdownt = timeStart;

                    checkFirstAttack = false;

                    Attacking();
            }
        }
        timeCountdownt -= Time.deltaTime;

        timeCountdownt = Mathf.Clamp(timeCountdownt, 0, Mathf.Infinity);

        if (nearestCharacter != null && isMoving == false)
        {
            transform.LookAt(nearestCharacter.transform);
        }
    
    }

    public void Attacking()
    {
        HideWeapon();

        MyAnimator.SetTrigger("IsAttack");

        if (nearestCharacter != null)
        {
            GameObject bulletSpawn = (GameObject)Instantiate(bullet, PointSpawnBullet.position, bullet.transform.rotation);

            bulletSpawn.GetComponent<BulletsWeapon>().setTargetPosition(nearestCharacter.transform.position);

            bulletSpawn.GetComponent<BulletsWeapon>().setOwnerChar(this.gameObject.GetComponent<CharacterManager>());

            bulletSpawn.GetComponent<BulletsWeapon>().setOwnerPos(this.transform.position);
        }
    }

   

    public void PlayerMovement()
    {
        isMoving = true;

        float xInput = joystick.Horizontal;

        float zInput = joystick.Vertical;

        Vector3 movementDirection = new Vector3(xInput, 0f, zInput);

        movementDirection.Normalize();

        transform.Translate(movementDirection * moveSpeed * Time.deltaTime, Space.World);

        animator.SetBool(AnimIdleTag, false);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed);

            //animator.SetBool(AnimIdleTag, false);

            checkFirstAttack = true;
        }
        else
        {
            isMoving = false;

            animator.SetBool(AnimIdleTag, true);
        }
    }
}
