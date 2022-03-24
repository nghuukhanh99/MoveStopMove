using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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

    public bool playerIsMoving;
    public void Start()
    {
        InvokeRepeating("Attack", 0f, 0.5f);
    }

    public void Update()
    {
        if (target == null)
        {
            return;
        }
    }
    public void Attack()
    {
        float shortestDistance = Mathf.Infinity;

        GameObject nearestCharacter = null;

        foreach(GameObject character in Characters)
        {
            float distanceToOtherCharacter = Vector3.Distance(transform.position, character.transform.position);

            if (distanceToOtherCharacter < shortestDistance)
            {
                shortestDistance = distanceToOtherCharacter;

                nearestCharacter = character;
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, range);
    }

    public void OnHit(int damage)
    {
        heal -= damage;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Character"))
        {
            Characters.Add(other.gameObject);

            if(playerIsMoving == false)
            {
                transform.LookAt(other.gameObject.transform);
            }

            Characters = Characters.Distinct().ToList();
        }
    }
}
