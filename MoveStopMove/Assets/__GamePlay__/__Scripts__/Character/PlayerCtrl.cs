using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PlayerCtrl : CharacterManager
{
    [SerializeField] FloatingJoystick joystick;

    [SerializeField] GameObject joystickObject;

    [SerializeField] private float moveSpeed;
    
    [SerializeField] private float rotationSpeed;

    [SerializeField] private Animator animator;

    public GameObject bullet;

    public float timeStart = 1.5f;

    public float timeCountdownt = 0;

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();

        if (GameManager.Instance.isGameActive == true)
        {
            joystickObject.SetActive(true);

            MyAnimator.SetBool(AnimDanceTag, false);
        }
        else
        {
            MyAnimator.SetBool(AnimDanceTag, true);
        }

        for(int i = 0; i < GameManager.Instance._listCharacter.Count; i++)
        {
            if (GameManager.Instance._listCharacter.Count == 1 && this == GameManager.Instance._listCharacter[i])
            {
                GameManager.Instance.isWin = true;
            }
        }

        if(this.isDead == true)
        {
            GameManager.Instance.isLose = true;
        }
      
        if(GameManager.Instance.isGameActive == true)
        {
            if (isDead == false)
            {
                PlayerMovement();
            }

            if (nearestCharacter != null)
            {
                if (Vector3.Distance(transform.position, nearestCharacter.transform.position) < range && timeCountdownt <= 0 && checkFirstAttack && isMoving == false)
                {
                    timeCountdownt = timeStart;

                    checkFirstAttack = false;

                    StartCoroutine(Attacking());
                }
            }
            timeCountdownt -= Time.deltaTime;

            timeCountdownt = Mathf.Clamp(timeCountdownt, 0, Mathf.Infinity);

            if (nearestCharacter != null && isMoving == false)
            {
                transform.LookAt(nearestCharacter.transform);
            }
        }

        if(timeCountdownt <= 0)
        {
            showWeapon();
        }
    }

    IEnumerator Attacking()
    {
        StartCoroutine(HideWeapon());

        yield return new WaitForSeconds(0.2f);

        MyAnimator.SetTrigger(AnimAttackTag);

        GameObject poolingBullet = null;

        if (bullet.name == HammerBulletName)
        {
            poolingBullet = PoolBullet.Instance.GetPooledBullet();
        }
        else if(bullet.name == CandyBulletName)
        {
            poolingBullet = PoolCandyBullet.Instance.GetPooledBullet();
        }
        else if(bullet.name == KnifeBulletName)
        {
            poolingBullet = PoolKnife.Instance.GetPooledBullet();
        }
     
        poolingBullet.transform.position = PointSpawnBullet.position;

        poolingBullet.transform.rotation = poolingBullet.transform.rotation;

        poolingBullet.SetActive(true);

        poolingBullet.GetComponent<BulletsWeapon>().setTargetPosition(nearestCharacter.transform.position);

        poolingBullet.GetComponent<BulletsWeapon>().setOwnerChar(this.gameObject.GetComponent<CharacterManager>());

        poolingBullet.GetComponent<BulletsWeapon>().setOwnerPos(this.transform.position);

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

            checkFirstAttack = true;
        }
        else
        {
            isMoving = false;

            animator.SetBool(AnimIdleTag, true);
        }
    }
}
