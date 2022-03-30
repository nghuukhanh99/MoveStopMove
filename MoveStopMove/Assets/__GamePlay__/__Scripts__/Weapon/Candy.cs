using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : Weapon
{
    float timer;

    public GameObject CandyBullet;

    public override void Attacking()
    {
        base.Attacking();

        CandyHand.SetActive(false);

        GameObject bullet = (GameObject)Instantiate(CandyBullet, spawnBullet.transform.position, Quaternion.identity);

        bullet.GetComponent<CandyBullet>().setTargetPosition(transform.position);
    }
}
