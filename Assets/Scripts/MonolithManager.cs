using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class MonolithManager : MonoBehaviour
{
    public Transform pylonRaise;
    public Transform pylonLower1;
    public Transform pylonLower2;

    public Transform pylonRaiseTarget;
    public Transform pylonLowerTarget1;
    public Transform pylonLowerTarget2;

    private bool hasBeenActivated = false;

    private Vector3 middleStart;
    private Vector3 middleTarget;

    private Vector3 sideStart1;
    private Vector3 sideStart2;
    private Vector3 sideTarget1;
    private Vector3 sideTarget2;

    public float range = 5f;

    public float moveSpeed = 1f;

    void Awake()
    {
        FindObjectOfType<PlayerController>().PlayerUse += MoveMonolith;
        InvokeRepeating("PlayerInRange", 1, 0.25f);
    }

    private void Update()
    {
        // if (hasBeenActivated)
        {
            //  pylonRaise.transform.position = Mathf.Lerp(transform.particleSystem, );
            //  pylonLower1.transform.position = Vector3.Lerp(transform.position, pylonLowerTarget1.position, moveSpeed);
            //  pylonLower2.transform.position = Vector3.Lerp(transform.position, pylonLowerTarget2.position, moveSpeed);
        }
    }

    void PlayerInRange()
    {
        if (!hasBeenActivated)
        {
            //FindObjectOfType<PlayerController>();
            //Debug.Log("Ping");
        }
    }


    void MoveMonolith()
    {
        if (!hasBeenActivated)
        {
            Debug.Log("Monolith has been activated");
            hasBeenActivated = true;
        }
        else
        {
            Debug.Log("Monolith already activated");
        }
    }
}