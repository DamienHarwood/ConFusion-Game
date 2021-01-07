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
    public float moveSpeed;
    public float jumpForce;

    public Rigidbody rb;
    private float playerScore;
    public float raycastSize = 0.5f;

    public GameManager gameManager;

    public float movementMixNumber;

    void Awake()
    {
        // get the rigidbody component
        rb = GetComponent<Rigidbody>();
        movementMixNumber = Random.Range(1, 6);
    }

    void Update()
    {
        //NoMixMove(); //Uncomment/comment when Movement needs to not be mixed around - useful for testing features.
        //Currently works well 02/01/21

        MixedMove(); //Uncomment/comment when Movement needs to be shuffled - this is how the controls should be for the game
        //Currently does not work 02/01/21
        

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
                    break;
                case 2: // Reversed
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
}