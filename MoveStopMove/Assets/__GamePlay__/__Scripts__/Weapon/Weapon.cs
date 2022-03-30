using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum WeaponType
//{
//    Candy,
//    Hammer,
//    Knife
//}
public class Weapon : MonoBehaviour
{
    public GameObject spawnBullet;

    public GameObject CandyHand;

    private void Start()
    {
        PlayerCtrl.attacking += Attacking;
    }
    public virtual void Attacking()
    {
        Debug.Log("IsAttack");
    }
}
