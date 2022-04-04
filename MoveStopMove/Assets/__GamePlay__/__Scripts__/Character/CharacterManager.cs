using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterManager : MonoBehaviour, IHit
{
    //string
    #region
    [HideInInspector] public string CharacterTag = "Character";

    [HideInInspector] public string AnimIdleTag = "IsIdle";

    [HideInInspector] public string AnimAttackTag = "IsAttack";

    [HideInInspector] public string AnimDeadTag = "IsDead";

    [HideInInspector] public string OndespawnTag = "OnDespawn";

    [HideInInspector] public string showWeaponTag = "showWeapon";

    [HideInInspector] public string bulletTag = "Bullet";

    #endregion

    //bool
    #region
    public bool isDead;

    public bool checkFirstAttack;

    public bool isMoving;

    #endregion

    //float
    #region
    public float range;

    public float timer;
    #endregion

    //GameObject
    #region
    public GameObject WeaponHand;

    [HideInInspector] public GameObject nearestCharacter;
    #endregion

    //Transform
    #region
    public Transform PointSpawnBullet;

    [HideInInspector] public Transform characterTransform;
    #endregion

    [SerializeField] int heal;

    public ParticleSystem effectOnDead;

    public Animator MyAnimator { get; private set; }
    public virtual void Start()
    {
        MyAnimator = GetComponent<Animator>();

        characterTransform = gameObject.GetComponent<Transform>();

        GameManager.Instance._listCharacter.Add(gameObject.GetComponent<CharacterManager>());

        nearestCharacter = null;
    }

    public virtual void Update()
    {
        FindAround();

        if(WeaponHand.activeSelf == false)
        {
            Invoke(showWeaponTag, 0.5f);
        }
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
            ParticleSystem effectDead = Instantiate(effectOnDead, transform.position, Quaternion.identity);

            Destroy(effectDead.gameObject, 1f);

            Invoke(OndespawnTag, 1.2f);

            MyAnimator.SetBool(AnimDeadTag, true);

            GameManager.Instance._listCharacter.Remove(this);
        }
    }

    public void showWeapon()
    {
        WeaponHand.SetActive(true);
    }

    public void HideWeapon()
    {
        WeaponHand.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(bulletTag))
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

    
    public void OnDespawn()
    {
        gameObject.SetActive(false);
    }

    public void OnHit(int damage)
    {
        heal -= damage;

        if (heal <= 0)
        {
            heal = 0;

            isDead = true;
        }

        OnDead();
    }
}

