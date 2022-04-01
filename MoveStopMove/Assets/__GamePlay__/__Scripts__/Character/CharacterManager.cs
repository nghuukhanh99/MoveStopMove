using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterManager : MonoBehaviour, IHit
{
    [HideInInspector] public string CharacterTag = "Character";

    [HideInInspector] public string AnimIdleTag = "IsIdle";

    [HideInInspector] public string AnimAttackTag = "IsAttack";

    [HideInInspector] public string AnimDeadTag = "IsDead";

    public Transform characterTransform;

    public GameObject nearestCharacter;

    public Animator MyAnimator { get; private set; }

    public bool Attack { get; set; }

    [SerializeField] int heal;

    public float range;

    public bool isMoving;

    public bool isDead;

    public float timer;

    public bool checkFirstAttack;

    public bool canAttack;

    public GameObject WeaponHand;

    public Transform PointSpawnBullet;

    public virtual void Start()
    {
        MyAnimator = GetComponent<Animator>();

        characterTransform = gameObject.GetComponent<Transform>();

        GameManager.Instance._listCharacter.Add(gameObject.GetComponent<CharacterManager>());

        nearestCharacter = null;

        canAttack = true;
    }

    public virtual void Update()
    {

        FindAround();
    }

    public void FindAround()
    {
        float shortestDistance = Mathf.Infinity;

        GameObject target = null;

        for (int i = 0; i < GameManager.Instance._listCharacter.Count; i++)
        {
            if(this != GameManager.Instance._listCharacter[i])
            {
                float distanceToOtherCharacter = Vector3.Distance(this.gameObject.transform.position, GameManager.Instance._listCharacter[i].transform.position);

                if (distanceToOtherCharacter < shortestDistance)
                {
                    shortestDistance = distanceToOtherCharacter;

                    target = GameManager.Instance._listCharacter[i].gameObject;

                    
                }
            }
        }
        nearestCharacter = target;

        if (target != null && shortestDistance < range)
        {
            nearestCharacter = target;
        }
        else
        {
            nearestCharacter = null;
        }
    }

    public void OnDead()
    {
        if(isDead == true)
        {
            Destroy(gameObject, 1.2f);

            MyAnimator.SetBool("IsDead", true);

            GameManager.Instance._listCharacter.Remove(this);
        }
    }

    public void HideWeapon()
    {
        
        WeaponHand.SetActive(false);

    }

    public void showWeapon()
    {
        WeaponHand.SetActive(true);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            CandyBullet bulletWeaponScript = other.gameObject.GetComponent<CandyBullet>();

            if (this != bulletWeaponScript.characterOwner) // kiem tra neu thang nem vu khi khac chinh no thi thuc hien
            {
                OnHit(10);

                Destroy(other.gameObject);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, range);
    }

    
    

    public void OnHit(int damage)
    {
        heal -= damage;

        if(heal <= 0)
        {
            heal = 0;

            isDead = true;
        }

        OnDead();
    }
}

