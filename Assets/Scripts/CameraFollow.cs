using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    void Update()
    {
        if (target == null)
        {
            Debug.Log("The Camera doesn't have a target set");
            return;
        }

        Vector3 newPos = target.position + offset;
        newPos.y = offset.y;
        transform.position = newPos;
    }
}