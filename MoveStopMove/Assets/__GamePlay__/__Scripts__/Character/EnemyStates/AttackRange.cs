using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    [SerializeField]
    private Enemy enemy;

    string playerTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(playerTag))
        {
            enemy.Target = other.gameObject.transform;

            //enemy.transform.LookAt(other.gameObject.transform);

            enemy.TargetList.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            enemy.Target = null;

            enemy.TargetList.Remove(other.gameObject);


        }
    }
}
