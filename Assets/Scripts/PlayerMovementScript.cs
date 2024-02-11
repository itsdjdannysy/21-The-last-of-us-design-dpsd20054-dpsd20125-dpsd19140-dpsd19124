using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public GameObject player;
    public GameObject sprite;
    public float moveSpeed = 5f;
    public float jumpForce = 700f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public float acceleration = 0.5f;
    public LayerMask whatIsGround;

    private Rigidbody2D rb;
    private Animator animator;
    private float moveInput;
    private bool isGrounded;
    private bool isJumping = false;
    private float currentSpeed = 0f;

    void Start()
    {
        animator = sprite.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check if the player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        moveInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetButton("Jump") && isGrounded)
        {

            isJumping = true;
        }
    }

    void FixedUpdate()
    {
        // Move the player
        if (moveInput != 0)
        {
            animator.SetBool("running", true);
            if (moveInput > 0)
            {
                this.player.transform.localScale = new Vector3(1, player.transform.localScale.y, player.transform.localScale.z);
            }
            if (moveInput < 0)
            {
                this.player.transform.localScale = new Vector3(-1, player.transform.localScale.y, player.transform.localScale.z);
            }
            currentSpeed += acceleration * moveInput;
            currentSpeed = Mathf.Clamp(currentSpeed, -moveSpeed, moveSpeed);
        }
        else
        {
            animator.SetBool("running", false);
            // Gradually stop the player when no input is detected
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0, acceleration * 10);
        }

        rb.velocity = new Vector2(currentSpeed, rb.velocity.y);

        if (isJumping)
        {
            animator.SetTrigger("jump");
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
            
    }
}
