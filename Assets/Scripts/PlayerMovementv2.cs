using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementv2 : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;

    [SerializeField] private float runSpeed = 10f;
    [SerializeField] private float jumpForce = 14f;

    [SerializeField] private float runState = 1f;

    [SerializeField] MovementState state;

    private enum MovementState { idle, walking, running, jumping, falling }

    //[SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal") * runState;
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("Left Shift down");
            runState = (runSpeed / moveSpeed);
        }
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("Not Left Shift");
            runState = 1f;
        }
    

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            //lumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        

        if (dirX > 0f)
        {
            state = MovementState.walking;
            
            
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                state = MovementState.running;
            }
            
            state = MovementState.walking;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}