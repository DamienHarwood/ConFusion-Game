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

    public Rigidbody rb;
    private float playerScore;
    public float raycastSize = 0.5f;

    public GameManager gameManager;

    public string keyA = "KeyCode.A";
    void Awake()
    {
        // get the rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //NoMixMove(); //Uncomment/comment when Movement needs to not be mixed around - useful for testing features.
        //Currently works well 02/01/21

        MixedMove(); //Uncomment/comment when Movement needs to be shuffled - this is how the controls should be for the game
        //Currently does not work 02/01/21
    }

    void MixedMove()
    {
        /*
         * 
         *-x = left
         * x = right
         *-z = down
         * z = up
         * 
         */
        Rigidbody rb = GetComponent<Rigidbody>();
        if (Input.GetKey(KeyCode.A))
            rb.AddForce(Vector3.left);
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(Vector3.right);
        if (Input.GetKey(KeyCode.W))
            rb.AddForce(Vector3.forward);
        if (Input.GetKey(KeyCode.S))
            rb.AddForce(Vector3.back);


       // if (Input.GetKey("d")) //right
        {
          //  Vector3 dir = new Vector3(1, 0, 0) * moveSpeed;
           // dir.y = rb.velocity.y;
          //  rb.velocity = dir;
        }
    }

    void NoMixMove()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");


        Vector3 dir = new Vector3(xInput, 0, zInput) * moveSpeed;
        dir.y = rb.velocity.y;

        rb.velocity = dir;
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