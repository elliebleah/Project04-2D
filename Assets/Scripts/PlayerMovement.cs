using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed
    public float jumpForce = 10f; // Jump force
    public Transform groundCheck; // Ground check object
    public float groundCheckRadius = 0.1f; // Radius for ground check
    public LayerMask groundLayer; // Layer for the ground objects
    public Animator animator; // Animator component
    public float scaleMultiplier = 0.4f; // Scale multiplier for x-axis

    private CharacterController controller;
    private bool isGrounded;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Movement
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float targetVelocityX = horizontalInput * moveSpeed;
        
        // Apply friction or damping to gradually slow down the player's velocity
        velocity.x = Mathf.Lerp(velocity.x, targetVelocityX, 0.1f);

        // Jumping
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Grounded");
            velocity.y = jumpForce;
        }

        // Apply gravity
        velocity.y += Physics2D.gravity.y * Time.deltaTime;

        // Move the player
        controller.Move(velocity * Time.deltaTime);

        // Flip the character sprite if moving left
        if (horizontalInput < 0)
        {
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-scaleMultiplier, 1, 1));
        }
        else if (horizontalInput > 0)
        {
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(scaleMultiplier, 1, 1));
        }
    }
}
