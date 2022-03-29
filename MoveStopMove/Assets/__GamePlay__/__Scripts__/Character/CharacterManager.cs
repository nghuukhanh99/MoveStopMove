using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public Animator MyAnimator { get; private set; }
    public bool Attack { get; set; }

    [SerializeField] int heal;

    public List<GameObject> Characters = new List<GameObject>();

    public string characterTag = "Character";

    public string AnimTagAttack = "IsAttack";

    public string AnimTagIdle = "IsIdle";

    public float range;

    public int attackCount;

    public int minAttackCount = 0;

    public int maxAttackCount = 1;

    public bool isMoving;

    public bool attacked;

    public bool haveTarget;

    public virtual void Start()
    {
        MyAnimator = GetComponent<Animator>();

    }

    public virtual void Update()
    {
        //FindTargets();

    }
    
    //}

    //public void Attacking()
    //{
    //    transform.LookAt(target);

    //    if (attackCount <= minAttackCount)
    //    {
    //        return;
    //    }

    //    if (attackCount >= maxAttackCount)
    //    {
    //        attacked = true;

    //        GetComponent<Animator>().SetTrigger(AnimTagAttack);

    //        if (isMoving == false)
    //        {
    //            attackCount--;
    //        }
    //    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, range);
    }

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(characterTag))
        {
            Characters.Add(other.gameObject);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(characterTag))
        {
            //target = null;

            Characters.Remove(other.gameObject);
        }

    }

    public void Play(AnimState state, Animator animator)
    {
        string animName = string.Empty;

        switch (state)
        {
            case AnimState.IsAttack:
                animName = AnimTagAttack;
                break;
        }

        animator.SetTrigger(animName);
    }
}

