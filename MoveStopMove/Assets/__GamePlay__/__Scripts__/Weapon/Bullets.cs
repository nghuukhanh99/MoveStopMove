using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<IHit>().OnHit(10);
        onDespawn();
    }

    void onDespawn()
    {
        gameObject.SetActive(false);
    }
}
