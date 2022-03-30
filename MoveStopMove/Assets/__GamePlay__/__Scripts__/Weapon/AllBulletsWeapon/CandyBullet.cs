using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyBullet : BulletsWeapon
{
    Vector3 positionTarget;

    Vector3 directBetweenPlayToTarget;
   

    public override void updateState()
    {
        base.updateState();

        positionTarget.y = 0.92f;

        Quaternion lookTarget = Quaternion.LookRotation(directBetweenPlayToTarget);

        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookTarget, Time.deltaTime * 30f).eulerAngles;

        directBetweenPlayToTarget = positionTarget - transform.position;

        transform.Translate(directBetweenPlayToTarget.normalized * Time.deltaTime * speed, Space.World);

        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

    }

    public void setTargetPosition(Vector3 _targetPos)
    {
        positionTarget = _targetPos;
    }
}
