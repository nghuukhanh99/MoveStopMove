using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyBullet : BulletsWeapon
{
    public override void updateState()
    {
        base.updateState();

        positionTarget.y = 0.92f;

        Quaternion lookTarget = Quaternion.LookRotation(fixedDirectToCharacter);

        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookTarget, Time.deltaTime * 30f).eulerAngles;

        transform.Translate(fixedDirectToCharacter * Time.deltaTime * speed, Space.World);

        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        
    }
}
