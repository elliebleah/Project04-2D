using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Regular movement speed
    public float runSpeed = 10f; // Running speed
    public float jumpForce = 10f; // Jump force
    public Transform groundCheck; // Ground check object
    public LayerMask groundLayer; // Layer for the ground objects
    public Animator animator; // Animator component

    private bool isGrounded;
    private bool isRunning;

    private bool isWalking;

    void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        // Movement
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        Vector3 newPosition = transform.position;

        // Handle horizontal movement
        if (horizontalInput != 0)
        {
            // Play walk or run animation
            animator.SetBool("isRunning", Input.GetKey(KeyCode.LeftShift));
            animator.SetBool("isWalking", true);
            // Set movement speed based on whether running or walking
            float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : moveSpeed;
            newPosition += new Vector3(horizontalInput * currentSpeed * Time.deltaTime, 0, 0);

            // Flip the character sprite if moving left
            if (horizontalInput < 0)
            {
                // Flip the sprite by scaling it negatively in the x-axis
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (horizontalInput > 0)
            {
                // Reset the sprite scale if moving right
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
        else
        {
            // Idle state
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
        }

        // Update player position
        transform.position = newPosition;

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("Jump");
            newPosition.y += jumpForce * Time.deltaTime;
            animator.SetBool("isJumping", true);
        }
        if (isGrounded)
        {
            Debug.Log("Grounded");
            animator.SetBool("isJumping", false);
        }
        if (!isGrounded)
        {
            Debug.Log("Not Grounded");
            //animator.SetBool("isJumping", false);
        }
    }
}
