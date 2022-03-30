using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : Weapon
{
    float timer;

    public GameObject CandyBullet;

    public Transform PointSpawnBullet;
    public override void Attacking()
    {
        base.Attacking();

        CandyHand.SetActive(false);

        GameObject bulletSpawn = (GameObject)Instantiate(CandyBullet, PointSpawnBullet.position, CandyBullet.transform.rotation);

        bulletSpawn.GetComponent<CandyBullet>().setTargetPosition(characterManager.nearestCharacter.transform.position);
    }
}
