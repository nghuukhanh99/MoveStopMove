﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterManager : MonoBehaviour
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

    

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, range);
    }
}

