using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletsWeapon : MonoBehaviour
{
    public float timer;

    public float speed;

    public Vector3 positionTarget;

    public Vector3 charOwnerPos;

    public Vector3 fixedDirectToCharacter;

    public CharacterManager characterOwner;

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer > 4f)
        {
            SimplePool.Despawn(gameObject);
        }

        updateState();
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    public virtual void updateState()
    {
        
    }


    public void autoDespawnIfOutOfRange()
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
