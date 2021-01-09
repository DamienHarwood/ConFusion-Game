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
    private bool hasBeenActivated = false;
    
    private Vector3 middleStart;
    private Vector3 middleTarget;

    private Vector3 sideStart1;
    private Vector3 sideStart2;
    private Vector3 sideTarget1;
    private Vector3 sideTarget2;
    
    public float range = 5f;

    public float moveSpeed = 1f;
    void Start()
    {
        middleStart = pylonRaise.position;
        middleTarget = middleStart + new Vector3(0, 4, 0);

        sideStart1 = pylonLower1.position;
        sideStart2 = pylonLower2.position;
        sideTarget1 = sideStart1 + new Vector3(0, -3f, 0);
        sideTarget2 = sideStart2 + new Vector3(0, -3f, 0);

        FindObjectOfType<PlayerController>().PlayerUse += MoveMonolith;
        InvokeRepeating("PlayerInRange", 5, 0.25f);
    }

    void PlayerInRange()
    {
        if (!hasBeenActivated)
        {
            //FindObjectOfType<PlayerController>();
            Debug.Log("Ping");
        }
        
    }
    
    
    


    void MoveMonolith()
    {
        if (!hasBeenActivated)
        {
            Debug.Log("Monolith has been activated");
           hasBeenActivated = true;
            
            pylonRaise.transform.position = Vector3.Lerp(middleStart, middleTarget, moveSpeed);
            pylonLower1.transform.position = Vector3.Lerp(sideStart1, sideTarget1, moveSpeed);
            pylonLower2.transform.position = Vector3.Lerp(sideStart2, sideTarget2, moveSpeed);

        }
        else
        {
            Debug.Log("Monolith already activated");
        }

    }
}
