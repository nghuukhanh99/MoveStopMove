using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : Weapon
{
    [SerializeField] WeaponData weaponData;

    private void Update()
    {
        Attack();
    }

    public override void Attack()
    {
        Debug.Log("Candy Attack");
        base.Attack();
    }
}
