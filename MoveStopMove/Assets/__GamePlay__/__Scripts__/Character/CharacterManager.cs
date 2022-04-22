using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class CharacterManager : MonoBehaviour, IHit
{
    //string
    #region
    [HideInInspector] public const string CharacterTag = "Character";

    [HideInInspector] public const string AnimIdleTag = "IsIdle";

    [HideInInspector] public const string AnimAttackTag = "IsAttack";

    [HideInInspector] public const string AnimDeadTag = "IsDead";

    [HideInInspector] public const string OndespawnTag = "OnDespawn";

    [HideInInspector] public const string showWeaponTag = "showWeapon";

    [HideInInspector] public const string bulletTag = "Bullet";

    [HideInInspector] public const string AnimDanceTag = "IsDance";

    [HideInInspector] public const string HammerBulletName = "Hammer Bullet";

    [HideInInspector] public const string CandyBulletName = "Candy Bullet";

    [HideInInspector] public const string KnifeBulletName = "Knife Bullet";

    [HideInInspector] public const string PlayerTag = "Player";
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
    
    public GameObject TargetFoot;

    #endregion
    //Transform
    #region
    public Transform PointSpawnBullet;

    [HideInInspector] public Transform characterTransform;
    #endregion

    [SerializeField] int heal;

    public ParticleSystem effectOnDead;

    public TextMeshProUGUI ScoreText;

    public int Score = 0;

    public GameObject bullet;

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

        if(this.gameObject.activeInHierarchy == false)
        {
            isDead = true;

            GameManager.Instance._listCharacter.Remove(this);
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
        
        if (target != null && shortestDistance < range * target.transform.localScale.z /* nhan voi scale cua nhan vat de thay foot target*/)
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

    public IEnumerator HideWeapon()
    {
        yield return new WaitForSeconds(0.42f);

        WeaponHand.SetActive(false);
    }

    public void FireBullet()
    {
        if(isMoving == true || nearestCharacter == null)
        {
            return;
        }

        GameObject poolingBullet = null;

        if (bullet.name == HammerBulletName)
        {
            poolingBullet = PoolBullet.Instance.GetPooledBullet();
        }
        else if (bullet.name == CandyBulletName)
        {
            poolingBullet = PoolCandyBullet.Instance.GetPooledBullet();
        }
        else if (bullet.name == KnifeBulletName)
        {
            poolingBullet = PoolKnife.Instance.GetPooledBullet();
        }

        SkinnedMeshRenderer weaponInHand = WeaponHand.gameObject.GetComponentInChildren<SkinnedMeshRenderer>();

        BulletsWeapon InfoBulletAfterPool = poolingBullet.GetComponent<BulletsWeapon>();

        CharacterManager typeOwnerChar = this.gameObject.GetComponent<CharacterManager>();

        poolingBullet.transform.localScale = this.transform.localScale;

        poolingBullet.transform.position = PointSpawnBullet.position;

        poolingBullet.transform.rotation = poolingBullet.transform.rotation;

        poolingBullet.SetActive(true);

        InfoBulletAfterPool.setTargetPosition(nearestCharacter.transform.position);

        InfoBulletAfterPool.setOwnerChar(typeOwnerChar);

        InfoBulletAfterPool.setOwnerPos(this.transform.position);

        SkinnedMeshRenderer skinBulletAfterPool = poolingBullet.GetComponentInChildren<SkinnedMeshRenderer>();

        //change color bullet follow weapon in hand
        skinBulletAfterPool.materials = weaponInHand.materials;
    }

    public IEnumerator Attacking()
    {
        MyAnimator.SetTrigger(AnimAttackTag);

        StartCoroutine(HideWeapon());

        yield return new WaitForSeconds(0.44f);

        FireBullet();
    }

    private void OnTriggerEnter(Collider other)
    {
        CandyBullet bulletWeaponScript = other.gameObject.GetComponent<CandyBullet>();

        if (other.gameObject.CompareTag(bulletTag))
        {
            if (this != bulletWeaponScript.characterOwner) // kiem tra neu thang nem vu khi khac chinh no thi thuc hien
            {
                OnHit(10);

                other.gameObject.SetActive(false);

                isDead = true;
            }

            if(this.name != bulletWeaponScript.characterOwner.name)
            {
                bulletWeaponScript.characterOwner.Score++;

                bulletWeaponScript.characterOwner.ScoreText.text = bulletWeaponScript.characterOwner.Score.ToString();

                bulletWeaponScript.characterOwner.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);

                bulletWeaponScript.characterOwner.range += 0.025f;

                if(bulletWeaponScript.characterOwner.tag == PlayerTag)
                {
                    GameManager.Instance.cameraOnMenu.m_Lens.FieldOfView += 2;

                    if(GameManager.Instance.cameraOnMenu.m_Lens.FieldOfView >= 70)
                    {
                        GameManager.Instance.cameraOnMenu.m_Lens.FieldOfView = 70;
                    }
                }

                if (bulletWeaponScript.characterOwner.range >= 0.4f)
                {
                    bulletWeaponScript.characterOwner.range = 0.4f;
                }

                if(bulletWeaponScript.characterOwner.transform.localScale.x >= 1.5)
                {
                    bulletWeaponScript.characterOwner.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                }
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

    public void GetWeaponHand(GameObject WeaponInHand)
    {
        WeaponHand = WeaponInHand;
    }
}

