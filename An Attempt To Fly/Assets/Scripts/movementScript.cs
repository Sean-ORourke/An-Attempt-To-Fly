using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 4f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float glideGravity = -0.5f; // Reduced gravity for gliding

    public int jumpCount = 1;
    public int jumpAllowance = 3;

    private Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public bool isGrounded;

    void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded) {
            jumpCount = 0;
        }
        // Get input for movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Apply movement
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // Check for jump
        if (Input.GetButtonDown("Jump") && jumpCount < jumpAllowance - 1)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // Jump velocity
            
            jumpCount++;
            Debug.Log(jumpCount);
        }

        // Apply gliding when the jump button is held
        if (Input.GetButton("Jump") && velocity.y < 0)
        {
            velocity.y += glideGravity * Time.deltaTime; // Glide by reducing downward speed
        }
        else
        {
            // Apply regular gravity when not gliding
            velocity.y += gravity * Time.deltaTime;
        }

        // Move the character with velocity (gravity/glide/jump)
        controller.Move(velocity * Time.deltaTime);
    }
}
