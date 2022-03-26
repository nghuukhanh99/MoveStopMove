using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour, IHit
{
    private static CharacterManager instance;
    public static CharacterManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<CharacterManager>();
            }

            return instance;
        }
    }

    [SerializeField] int heal;

    public List<GameObject> Characters = new List<GameObject>();

    public Transform target;

    public float range;
    public virtual void Start()
    {
        InvokeRepeating("FindTargets", 0f, 0.5f);
    }

    public virtual void Update()
    {
        if(target == null)
        {
            return;
        }
    }
    public void FindTargets()
    {
        float shortestDistance = Mathf.Infinity;

        GameObject nearestCharacter = null;

        for(int i = 0; i < this.Characters.Count; i++)
        {
            float distanceToOtherCharacter = Vector3.Distance(transform.position, this.Characters[i].transform.position);

            if(distanceToOtherCharacter < shortestDistance)
            {
                shortestDistance = distanceToOtherCharacter;

                nearestCharacter = this.Characters[i];
            }
        }

        if (nearestCharacter != null && shortestDistance < range)
        {
            target = nearestCharacter.transform;
        }
        else
        {
            target = null;
        }
    }

    public virtual void Attack()
    {
        
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
        if (other.CompareTag("Character"))
        {
            if (!Characters.Contains(other.gameObject))
            {
                Characters.Add(other.gameObject);
            }
        }
    }
}
