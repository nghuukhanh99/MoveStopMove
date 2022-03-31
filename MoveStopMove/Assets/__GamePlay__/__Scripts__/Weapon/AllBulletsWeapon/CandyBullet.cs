using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyBullet : BulletsWeapon
{
    Vector3 positionTarget;

    Vector3 directBetweenPlayToTarget;

    Vector3 charOwnerPos;

    public CharacterManager characterOwner;

    Vector3 fixedDirectToCharacter;

    public override void updateState()
    {
        base.updateState();

        positionTarget.y = 0.92f;

        Quaternion lookTarget = Quaternion.LookRotation(fixedDirectToCharacter);

        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookTarget, Time.deltaTime * 30f).eulerAngles;

        transform.Translate(fixedDirectToCharacter * Time.deltaTime * speed, Space.World);

        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        autoDespawnIfOutOfRange();

    }

    private void autoDespawnIfOutOfRange()
    {

        if (Vector3.Distance(charOwnerPos, transform.position) > characterOwner.range)
        {
            Destroy(gameObject);
        }
    }
    public void setOwnerPos(Vector3 _charOwnerPos)
    {
        //Debug.Log(_characterOwner);
        charOwnerPos = _charOwnerPos;

        fixedDirectToCharacter = (positionTarget - charOwnerPos).normalized;
    }
    public void setTargetPosition(Vector3 _targetPos)
    {
        positionTarget = _targetPos;
    }

    public void setOwnerChar(CharacterManager _characterOwner)
    {
        characterOwner = _characterOwner;
    }

}
