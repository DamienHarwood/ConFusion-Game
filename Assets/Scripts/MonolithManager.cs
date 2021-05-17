using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEngine;


public class MonolithManager : MonoBehaviour
{
    public Transform pylonRaise;
    public Transform pylonLower1;
    public Transform pylonLower2;

    public Transform pylonRaiseTarget;
    public Transform pylonLowerTarget1;
    public Transform pylonLowerTarget2;

    public bool hasBeenActivated;
    public bool canActivate;

    private float moveSpeed = 2f;

    public Rigidbody player;
    private PlayerController playerController;

    void Start()
    {
        hasBeenActivated = false;
        playerController = FindObjectOfType<PlayerController>();
        player = playerController.rb;
        FindObjectOfType<PlayerController>().PlayerUse += TryActivate;
    }


    IEnumerator MovePylons()
    {
        float startTime = Time.time;
        while (Time.time < startTime + moveSpeed)
        {
            pylonRaise.transform.position = Vector3.Lerp(pylonRaise.position, pylonRaiseTarget.position,
                (Time.time - startTime) / moveSpeed);
            pylonLower1.transform.position = Vector3.Lerp(pylonLower1.position, pylonLowerTarget1.position,
                (Time.time - startTime) / moveSpeed);
            pylonLower2.transform.position = Vector3.Lerp(pylonLower2.position, pylonLowerTarget2.position,
                (Time.time - startTime) / moveSpeed);
            yield return null;
        }

        pylonRaise.transform.position = pylonRaiseTarget.position;
        pylonLower1.transform.position = pylonLowerTarget1.position;
        pylonLower2.transform.position = pylonLowerTarget2.position;
    }

    void Activate()
    {
        //Debug.Log("Activated");
        StartCoroutine(MovePylons());
        hasBeenActivated = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canActivate = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canActivate = false;
        }
    }


    void TryActivate()
    {
        if (canActivate && !hasBeenActivated)
        {
            Activate();
        }
        else
        {
            //Debug.Log("Cannot Activate");
        }
    }
}