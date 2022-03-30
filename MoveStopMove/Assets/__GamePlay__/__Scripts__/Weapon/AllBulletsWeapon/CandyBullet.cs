using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyBullet : BulletsWeapon
{
    public Rigidbody rb;

    Vector3 positionTarget;

    Vector3 directBetweenPlayToTarget;
   

    public override void updateState()
    {
        base.updateState();

        directBetweenPlayToTarget = positionTarget - transform.position;

        transform.Translate(directBetweenPlayToTarget.normalized * Time.deltaTime * speed, Space.World);
    }

    public void setTargetPosition(Vector3 _targetPos)
    {
        positionTarget = _targetPos;
    }
}
