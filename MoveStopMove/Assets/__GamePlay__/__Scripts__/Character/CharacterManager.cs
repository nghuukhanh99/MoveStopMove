using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [HideInInspector] public string CharacterTag = "Character";

    [HideInInspector] public string AnimIdleTag = "IsIdle";

    [HideInInspector] public string AnimAttackTag = "IsAttack";

    [HideInInspector] public string AnimDeadTag = "IsDead";

    public Animator MyAnimator { get; private set; }
    public bool Attack { get; set; }

    public List<GameObject> TargetList = new List<GameObject>();

    public Transform Target { get; set; }

    [SerializeField] int heal;

    public float range;

    public bool isMoving;



    public virtual void Start()
    {
        MyAnimator = GetComponent<Animator>();
    }

    public virtual void Update()
    {
        if (isMoving == true)
        {
            FindAround();
        }
    }

    public void FindAround()
    {
        float shortestDistance = Mathf.Infinity;

        GameObject nearestCharacter = null;

        for (int i = 0; i < this.TargetList.Count; i++)
        {
            float distanceToOtherCharacter = Vector3.Distance(transform.position, this.TargetList[i].transform.position);

            if (distanceToOtherCharacter < shortestDistance)
            {
                shortestDistance = distanceToOtherCharacter;

                nearestCharacter = this.TargetList[i];
            }
        }

        if (nearestCharacter != null && shortestDistance < range)
        {
            Target = nearestCharacter.transform;
        }
        else
        {
            Target = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, range);
    }
}

