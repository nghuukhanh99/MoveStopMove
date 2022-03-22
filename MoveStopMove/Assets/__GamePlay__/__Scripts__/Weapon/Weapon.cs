using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public List<GameObject> WeaponList = new List<GameObject>();

    [SerializeField] private float speed;

    public virtual void Attack()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position, speed * Time.deltaTime);

    }
    
    
}
