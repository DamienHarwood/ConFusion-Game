using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.Rendering;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpForce = 200f;
    public float movementMixNumber;
    public float groundDistance = 0.4f;

    public float movement = 1;
    public LayerMask groundMask;

    public Transform groundCheck;

    private float playerScore;

    public bool canJump;

    public event Action PlayerUse;


    void Awake()
    {
        // get the rigidbody component

        Rigidbody rb = GetComponent<Rigidbody>();
        movementMixNumber = Random.Range(1, 7); //chooses which movement scheme to go with for a given level

        //FOR TESTING - Disables the mixed controls
        // movementMixNumber = 1; //Uncomment when testing to stop mixing
    }

    void FixedUpdate()
    {
        //checks to see if the collider at the players feet is touching the ground
        canJump = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        MixedMove();
    }


    private void OnTriggerEnter(Collider other)
    {
        throw new NotImplementedException();
        //not used yet, will be used for the end of the level transition and some
        //other things like monoliths and buttons. not sure if I should be putting this
        //on the player or in the game manager. For now I'm going to put it on the player
        //because that makes more sense at this point. maybe I'll change later.
    }

    void MixedMove()
    {
        //TODO: Find a better way of mixing controls, or at least a more condensed version
        switch (movementMixNumber)
        {
            case 1: // Not Mixed
                if (Input.GetKey(KeyCode.A)) //Left
                    rb.AddForce(Vector3.left * movement);
                if (Input.GetKey(KeyCode.D)) //Right
                    rb.AddForce(Vector3.right * movement);
                if (Input.GetKey(KeyCode.W)) //Up
                    rb.AddForce(Vector3.forward * movement);
                if (Input.GetKey(KeyCode.S)) //Down
                    rb.AddForce(Vector3.back * movement);
                if (Input.GetKeyDown(KeyCode.Space)) //Jump
                    TryJump();
                if (Input.GetKeyDown(KeyCode.E)) //Use
                    Use();
                break;
            case 2: //Reversed
                //Rigidbody rb = GetComponent<Rigidbody>();
                if (Input.GetKey(KeyCode.D)) //Left
                    rb.AddForce(Vector3.left * movement);
                if (Input.GetKey(KeyCode.A)) //Right
                    rb.AddForce(Vector3.right * movement);
                if (Input.GetKey(KeyCode.S)) //Up
                    rb.AddForce(Vector3.forward * movement);
                if (Input.GetKey(KeyCode.W)) //Down
                    rb.AddForce(Vector3.back * movement);
                if (Input.GetKeyDown(KeyCode.Space))
                    TryJump();
                break;
            case 3:
                //Rigidbody rb = GetComponent<Rigidbody>();
                if (Input.GetKey(KeyCode.S)) //Left
                    rb.AddForce(Vector3.left * movement);
                if (Input.GetKey(KeyCode.Space)) //Right
                    rb.AddForce(Vector3.right * movement);
                if (Input.GetKey(KeyCode.W)) //Up
                    rb.AddForce(Vector3.forward * movement);
                if (Input.GetKey(KeyCode.A)) //Down
                    rb.AddForce(Vector3.back * movement);
                if (Input.GetKeyDown(KeyCode.D))
                    TryJump();
                break;
            case 4:
                if (Input.GetKey(KeyCode.Space)) //Left
                    rb.AddForce(Vector3.left * movement);
                if (Input.GetKey(KeyCode.W)) //Right
                    rb.AddForce(Vector3.right * movement);
                if (Input.GetKey(KeyCode.S)) //Up
                    rb.AddForce(Vector3.forward * movement);
                if (Input.GetKey(KeyCode.D)) //Down
                    rb.AddForce(Vector3.back * movement);
                if (Input.GetKeyDown(KeyCode.A))
                    TryJump();
                break;
            case 5:
                if (Input.GetKey(KeyCode.W)) //Left
                    rb.AddForce(Vector3.left * movement);
                if (Input.GetKey(KeyCode.A)) //Right
                    rb.AddForce(Vector3.right * movement);
                if (Input.GetKey(KeyCode.D)) //Up
                    rb.AddForce(Vector3.forward * movement);
                if (Input.GetKey(KeyCode.Space)) //Down
                    rb.AddForce(Vector3.back * movement);
                if (Input.GetKeyDown(KeyCode.S))
                    TryJump();
                break;
            case 6:
                if (Input.GetKey(KeyCode.A)) //Left
                    rb.AddForce(Vector3.left * movement);
                if (Input.GetKey(KeyCode.Space)) //Right
                    rb.AddForce(Vector3.right * movement);
                if (Input.GetKey(KeyCode.S)) //Up
                    rb.AddForce(Vector3.forward * movement);
                if (Input.GetKey(KeyCode.W)) //Down
                    rb.AddForce(Vector3.back * movement);
                if (Input.GetKeyDown(KeyCode.D))
                    TryJump();
                break;
            case 7:
                if (Input.GetKey(KeyCode.S)) //Left
                    rb.AddForce(Vector3.left * movement);
                if (Input.GetKey(KeyCode.W)) //Right
                    rb.AddForce(Vector3.right * movement);
                if (Input.GetKey(KeyCode.A)) //Up
                    rb.AddForce(Vector3.forward * movement);
                if (Input.GetKey(KeyCode.Space)) //Down
                    rb.AddForce(Vector3.back * movement);
                if (Input.GetKeyDown(KeyCode.D))
                    TryJump();
                break;
            default:
                Debug.Log("There is a problem with the control selection");
                break;
        }
    }

    /*void NoMixMove() //Unused code. Will remove later
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");


        Vector3 dir = new Vector3(xInput, 0, zInput) * moveSpeed;
        dir.y = rb.velocity.y;

        rb.velocity = dir;
    }*/

    void TryJump()
    {
        if (canJump)
        {
            rb.AddForce(0, jumpForce, 0);
        }
    }

    void Use()
    {
        Debug.Log("Use");
        PlayerUse?.Invoke();
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