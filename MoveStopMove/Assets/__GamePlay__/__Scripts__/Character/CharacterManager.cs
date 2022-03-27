using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour, IHit
{
    [SerializeField] int heal;

    public List<GameObject> Characters = new List<GameObject>();

    public Transform target;

    public float range;

    public int attackCount;

    public int minAttackCount = 0;

    public int maxAttackCount = 1;

    public bool isMoving;

    public bool attacked;

    public bool haveTarget;
    public virtual void Start()
    {
        InvokeRepeating("FindTargets", 0f, 0.5f);

    }

    public virtual void Update()
    {
        if (target == null)
        {
            return;
        }

        if (isMoving == false)
        {
            transform.LookAt(target);
        }

        if(attacked == true)
        {
            if (attackCount <= minAttackCount)
            {
                return;
            }

            attackCount--;
        }

        //if(haveTarget == true && isMoving == false)
        //{
        //    if(attackCount > maxAttackCount)
        //    {
        //        return;
        //    }

        //    attackCount++;
        //}
    }
    public void FindTargets()
    {
        float shortestDistance = Mathf.Infinity;

        GameObject nearestCharacter = null;

        for (int i = 0; i < this.Characters.Count; i++)
        {
            float distanceToOtherCharacter = Vector3.Distance(transform.position, this.Characters[i].transform.position);

            if (distanceToOtherCharacter < shortestDistance)
            {
                shortestDistance = distanceToOtherCharacter;

                nearestCharacter = this.Characters[i];
            }
        }

        if (nearestCharacter != null && shortestDistance < range)
        {
            target = nearestCharacter.transform;

            haveTarget = true;
        }

        else
        {
            target = null;

            haveTarget = false;
        }

    }

    public virtual void Attack()
    {
        if(attackCount >= maxAttackCount)
        {
            GetComponent<Animator>().SetTrigger("IsAttack");

            attacked = true;
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
    }

    private void OnTriggerEnter(Collider other)
    {
        FindTargets();

        if (other.CompareTag("Character"))
        {
            Characters.Add(other.gameObject);

            Attack();

            
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Character"))
        {
            target = null;
            Characters.Remove(other.gameObject);
        }

    }
}
