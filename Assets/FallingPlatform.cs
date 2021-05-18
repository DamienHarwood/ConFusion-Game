using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody platformRB;
    public Transform platformTransform;

    private Material platformMat;
    
    public Vector3 originalLocation;
    public bool isOnFallingPlatform;
    public bool platformFallen;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        platformRB = GetComponentInParent<Rigidbody>();
        platformTransform = GetComponentInParent<Transform>(); //This is not getting the parent transform for some reason
        originalLocation = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != originalLocation)
        {
            platformFallen = true;
            if (!isOnFallingPlatform)
            {
                StartCoroutine(PlatformResetting(5, 1));
            }
        }

        if (transform.position == originalLocation)
        {
            platformFallen = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOnFallingPlatform = true;
            StartCoroutine(PlatformFall(1));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isOnFallingPlatform = false;
    }

    IEnumerator PlatformFall(float intervalTime)
    {
        yield return new WaitForSeconds(intervalTime);
       // platformMat.color = Color.Lerp(Color.white, Color.clear, intervalTime * Time.deltaTime);
        yield return new WaitForSeconds(intervalTime);
        
        platformRB.constraints = RigidbodyConstraints.None;

        Debug.Log("End of routine");
    }

    IEnumerator PlatformResetting(float waitTime, float moveTime)
    {
        if (isOnFallingPlatform)
        {
            yield break;
        }
        yield return new WaitForSeconds(waitTime);
        if (isOnFallingPlatform)
        {
            yield break;
        }

        platformRB.isKinematic = true;
        platformTransform.position = Vector3.Lerp(transform.position, originalLocation, moveTime * Time.deltaTime);
        platformRB.constraints = RigidbodyConstraints.FreezeAll;
        platformRB.isKinematic = false;
        

    }
}
