using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    private Rigidbody rig;

    private float playerScore;
    Renderer render;
    public float raycastSize = 0.5f;

    public GameManager gameManager;

    void Awake()
    {
        // get the rigidbody component
        rig = GetComponent<Rigidbody>();
        render = GetComponent<Renderer>();
    }

    void Update()
    {
       NoMixMove(); //Uncomment/comment when Movement needs to not be mixed around - useful for testing features.
                    //Currently works well 02/01/21
                    
      // MixedMove(); //Uncomment/comment when Movement needs to be shuffled - this is how the controls should be for the game
                    //Currently does not work 02/01/21
    }

    void MixedMove()
    {
        if (Input.GetKey("a"))
        {
            Vector3 dir = new Vector3(-1, 0, 0) * moveSpeed;
            dir.y = rig.velocity.y;
            rig.velocity = dir;
        }
        
        if (Input.GetKey("w"))
        {
            Vector3 dir = new Vector3(0, 0, 1) * moveSpeed;
            dir.y = rig.velocity.y;
            rig.velocity = dir;
        }
        
        if (Input.GetKey("s"))
        {
            Vector3 dir = new Vector3(0, 0, -1) * moveSpeed;
            dir.y = rig.velocity.y;
            rig.velocity = dir;
        }
        
        if (Input.GetKey("d"))
        {
            Vector3 dir = new Vector3(1, 0, 0) * moveSpeed;
            dir.y = rig.velocity.y;
            rig.velocity = dir;
        }
    }
    
    void NoMixMove()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");


        Vector3 dir = new Vector3(xInput, 0, zInput) * moveSpeed;
        dir.y = rig.velocity.y;

        rig.velocity = dir;
    }


    /*public void OnTriggerEnter(Collider other)

    {
        if (other.CompareTag("Coin"))
        {
            gameManager.coinsCollected++;
            Destroy(gameObject);
        }
        else if (other.CompareTag("Goal"))
        {
            GameManager.instance.LevelEnd();
        }
    }*/
}