using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
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


    void Awake()
    {
        // get the rigisbody component
        rig = GetComponent<Rigidbody>();
        render = GetComponent<Renderer>();
    }

    void Update()
    {
        Move();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(new Vector3( raycastSize, 0, raycastSize),(new Vector3( raycastSize, 0, raycastSize)));
        Gizmos.DrawLine(new Vector3( -raycastSize, 0, raycastSize),(new Vector3( -raycastSize, 0, raycastSize)));
        Gizmos.DrawLine(new Vector3( raycastSize, 0, -raycastSize),(new Vector3( raycastSize, 0, -raycastSize)));
        Gizmos.DrawLine(new Vector3( -raycastSize, 0, -raycastSize),(new Vector3( -raycastSize, 0, -raycastSize)));

    }

    void Move()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");


        Vector3 dir = new Vector3(xInput, 0, zInput) * moveSpeed;
        dir.y = rig.velocity.y;

        rig.velocity = dir;
       
        if (Input.GetButtonDown("Jump"))
        {
            TryJump();
        }
        
    }
    
    void TryJump()
    {
        Ray ray1 = new Ray(transform.position + new Vector3(raycastSize, 0, raycastSize), Vector3.down);
        Ray ray2 = new Ray(transform.position + new Vector3(-raycastSize, 0, raycastSize), Vector3.down);
        Ray ray3 = new Ray(transform.position + new Vector3(raycastSize, 0, -raycastSize), Vector3.down);
        Ray ray4 = new Ray(transform.position + new Vector3(-raycastSize, 0, -raycastSize), Vector3.down);
        
        //Gizmos.DrawLine(ray1, Vector3.down);

        bool cast1 = Physics.Raycast(ray1, 0.7f);
        bool cast2 = Physics.Raycast(ray2, 0.7f);
        bool cast3 = Physics.Raycast(ray3, 0.7f);
        bool cast4 = Physics.Raycast(ray4, 0.7f);

        if (cast1 || cast2 || cast3 || cast4)
        {
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    public void OnTriggerEnter(Collider other)

    {
        if (other.CompareTag("Enemy"))
        {
            GameManager.instance.GameOver();
            render.material.color = Color.black;
        }
        else if (other.CompareTag("Goal"))
        {
            GameManager.instance.LevelEnd();
        }
    }
}