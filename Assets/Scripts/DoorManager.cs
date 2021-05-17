using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public Transform door;
    public Transform wallTarget;
    
    public bool hasBeenActivated;
    public bool canActivate;
    
    private float moveSpeed = 10f;

    public Rigidbody player;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        hasBeenActivated = false;
        playerController = FindObjectOfType<PlayerController>();
        player = GameObject.Find("Player").GetComponent<Rigidbody>();
        player = playerController.rb;
        FindObjectOfType<PlayerController>().PlayerUse += TryActivate;
    }

    IEnumerator OpenDoor()
    {
        float startTime = Time.time;
        while(Time.time < startTime + moveSpeed)
        {
            Debug.Log("Still Running routine");
            door.transform.position = Vector3.Lerp(door.position, wallTarget.position - new Vector3(0f, 0f, -0.1f), (Time.time - startTime)/moveSpeed);
            yield return null;
        }
        Debug.Log("Hard Set pos");
       // door.transform.position = wallTarget.position;
    }
    
    void Activate()
    {
        //Debug.Log("Opened");
        StartCoroutine("OpenDoor");
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
            //Debug.Log("Cannot Open");
        }
    }
}
