using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 2f, gravity = -9.8f, groundDistance = 5f, jumpHeight = 2f,floorHeight=6f;
    public int playerCurFloor;

    Vector3 velocity;

    public Transform feet;
    public LayerMask groundLayer;
    bool isGrounded;
    public GameObject elevator;
    Rigidbody rb;



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(feet.position, groundDistance, groundLayer);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;



        rb.velocity = new Vector3(move.x * speed * Time.deltaTime, rb.velocity.y,move.z * speed * Time.deltaTime) ;
       

        
        

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpHeight);
        }



        PlayerCurrFloorMath();


    }

    public void PlayerCurrFloorMath()
    {
        if (transform.position.y % floorHeight -0.89 < 0.1f )
        {
            playerCurFloor = (int)(transform.position.y / floorHeight);
        }
    }
}
