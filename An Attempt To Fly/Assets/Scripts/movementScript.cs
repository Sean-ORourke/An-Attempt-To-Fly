using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 6f;
    public float gravity = -9.81f;
    public float jumpHeight = 1.5f;

    private Vector3 velocity;
    private bool isGrounded;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Slight push to ensure player stays grounded
        }

        // Get input for movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Apply movement in the character's forward direction
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // Jump
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
            else
            {
                velocity.y = Mathf.Sqrt(-2f * gravity);
                // reference your notes for further development
                //while (!isGrounded)
                //{
                //    velocity.y = 1;
                //}
                //velocity.y = Mathf.Sqrt(-2f * gravity);
            }



        }

        //if (Input.GetButton("Jump"))
        //{
        //    velocity.y = 1;
        //}


        // Apply gravity
        velocity.y += gravity * Time.deltaTime;

        // Move character with gravity
        controller.Move(velocity * Time.deltaTime);
    }

}


