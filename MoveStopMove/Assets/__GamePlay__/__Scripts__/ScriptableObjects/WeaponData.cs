using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon/Throw Weapon")]
public class WeaponData : ScriptableObject
{
    [Header("Info")]
    public new string name;

    public WeaponType weaponType;

    [Header("Shooting")]
    public float damage;

    public float speed;

    public float maxDistance;

}
