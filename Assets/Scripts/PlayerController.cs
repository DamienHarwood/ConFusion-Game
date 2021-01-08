using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.Rendering;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    public float jumpForce = 200f;
    
    public Rigidbody rb;
    private float playerScore;

    public float movementMixNumber;

    public bool canJump;
    public float DeploymentHeight = 1;

    void Awake()
    {
        // get the rigidbody component
        rb = GetComponent<Rigidbody>();
        movementMixNumber = Random.Range(1, 6); //chooses which movement scheme to go with for a given level
       // movementMixNumber = 1; //Uncomment when testing to stop mixing
    }

    void Update()
    {
        MixedMove();
        
    }
    
    

    void MixedMove()
        {

            Rigidbody rb = GetComponent<Rigidbody>();
            switch (movementMixNumber)
            {
                case 1: // Not Mixed

                    if (Input.GetKey(KeyCode.A)) //Left
                        rb.AddForce(Vector3.left);
                    if (Input.GetKey(KeyCode.D)) //Right
                        rb.AddForce(Vector3.right);
                    if (Input.GetKey(KeyCode.W)) //Up
                        rb.AddForce(Vector3.forward);
                    if (Input.GetKey(KeyCode.S)) //Down
                        rb.AddForce(Vector3.back);
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        {
                            rb.AddForce(0, jumpForce, 0);
                        }
                    }
                    break;
                case 2: //Reversed
                    //Rigidbody rb = GetComponent<Rigidbody>();
                    if (Input.GetKey(KeyCode.D)) //Left
                        rb.AddForce(Vector3.left);
                    if (Input.GetKey(KeyCode.A)) //Right
                        rb.AddForce(Vector3.right);
                    if (Input.GetKey(KeyCode.S)) //Up
                        rb.AddForce(Vector3.forward);
                    if (Input.GetKey(KeyCode.W)) //Down
                        rb.AddForce(Vector3.back);
                    break;
                case 3:
                    //Rigidbody rb = GetComponent<Rigidbody>();
                    if (Input.GetKey(KeyCode.S)) //Left
                        rb.AddForce(Vector3.left);
                    if (Input.GetKey(KeyCode.D)) //Right
                        rb.AddForce(Vector3.right);
                    if (Input.GetKey(KeyCode.W)) //Up
                        rb.AddForce(Vector3.forward);
                    if (Input.GetKey(KeyCode.A)) //Down
                        rb.AddForce(Vector3.back);
                    break;
                case 4:
                    if (Input.GetKey(KeyCode.A)) //Left
                        rb.AddForce(Vector3.left);
                    if (Input.GetKey(KeyCode.W)) //Right
                        rb.AddForce(Vector3.right);
                    if (Input.GetKey(KeyCode.S)) //Up
                        rb.AddForce(Vector3.forward);
                    if (Input.GetKey(KeyCode.D)) //Down
                        rb.AddForce(Vector3.back);
                    break;
                case 5:
                    if (Input.GetKey(KeyCode.W)) //Left
                        rb.AddForce(Vector3.left);
                    if (Input.GetKey(KeyCode.A)) //Right
                        rb.AddForce(Vector3.right);
                    if (Input.GetKey(KeyCode.D)) //Up
                        rb.AddForce(Vector3.forward);
                    if (Input.GetKey(KeyCode.S)) //Down
                        rb.AddForce(Vector3.back);
                    break;
                default:
                    Debug.Log("There is a problem with the control selection");
                    break;
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
        
        void TryJump()
        {
            
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
