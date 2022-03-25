using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Candy,
    Hammer,
    Knife
}
public class Weapon : MonoBehaviour
{
    public Transform weaponHolder;
    public virtual void Attack()
    {
        
    }
}
