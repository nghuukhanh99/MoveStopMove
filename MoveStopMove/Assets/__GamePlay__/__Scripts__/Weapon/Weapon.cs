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
    protected CharacterManager characterManager;

    public GameObject spawnBullet;

    public GameObject CandyHand;

    private void Start()
    {
        characterManager = GetComponent<CharacterManager>();

        PlayerCtrl.attacking += Attacking;
    }
    public virtual void Attacking()
    {
        
    }
}
