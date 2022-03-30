using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyJoystick;
using System;

public class PlayerCtrl : CharacterManager, IHit
{
    [SerializeField] Joystick joystick;

    [SerializeField] private float moveSpeed;
    
    [SerializeField] private float rotationSpeed;

    [SerializeField] private Animator animator;

    public GameObject bullet;

    public Transform PointSpawnBullet;

    public float timeStart = 1.5f;

    public float timeCountdownt = 0;

    public static Action attacking;

    [SerializeField] private GameObject CandyHand;

    int heal = 10;
    
    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();

        PlayerMovement();

        if(nearestCharacter != null && timeCountdownt <= 0)
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
        HideWeapon();

        if (nearestCharacter != null)
        {
            GameObject bulletSpawn = (GameObject)Instantiate(bullet, PointSpawnBullet.position, bullet.transform.rotation);

            bulletSpawn.GetComponent<CandyBullet>().setTargetPosition(nearestCharacter.transform.position);
        }
    }

    public void ShowWeapon()
    {
        if(CandyHand != null)
        {
            CandyHand.SetActive(true);
        }
    }
    public void HideWeapon()
    {
        if(PointSpawnBullet.childCount > 0)
        {
            CandyHand = PointSpawnBullet.GetChild(0).gameObject;
        }
        if(CandyHand != null)
        {
            CandyHand.SetActive(false);   
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

    public void OnHit(int damage)
    {
        heal -= damage;
    }
}
