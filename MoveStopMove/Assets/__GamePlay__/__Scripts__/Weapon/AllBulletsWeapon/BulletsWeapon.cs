using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletsWeapon : MonoBehaviour
{
    public float timer;

    public float speed;

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer > 4f)
        {
            Despawn(gameObject);
        }

        updateState();

    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<IHit>().OnHit(10);

        Despawn(other.gameObject);
    }

    public virtual void updateState()
    {
        
    }


    public virtual void OnHit()
    {

    }
    

    private void Despawn(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
    
    
}
