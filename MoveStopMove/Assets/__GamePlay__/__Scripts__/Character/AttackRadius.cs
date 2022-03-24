using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRadius : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Character"))
        {
            gameObject.GetComponentInParent<Animator>().SetBool("IsIdle", true);
        }
    }
}

