using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform Current;

    public Vector3 offset;
    void Update()
    {
        transform.position = Current.position + offset;
    }
}
