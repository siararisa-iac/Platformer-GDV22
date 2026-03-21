using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float jumpForce = 200f;

    [Header("Ground Check")]
    [SerializeField]
    // A reference to where the "feet" or ground point of the player is
    private Transform groundPoint;

    [SerializeField]
    // How big is the radius of our ground checker
    private float groundRadius = 0.2f;

    [SerializeField]
    // What layers are considered as a ground
    private LayerMask groundLayers;


    private Rigidbody2D playerRb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private float horizontalInput;
    private bool isFacingRight = true;
    private bool isJump = false;


    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Where we get input
    private void Update()
    {
        // Store input data in update because controls need to be updated every frame
        horizontalInput = Input.GetAxis("Horizontal");
        float animationMoveSpeed = Mathf.Abs(horizontalInput);
        if (animator != null)
        {
            animator.SetFloat("moveSpeed", animationMoveSpeed);
        }

        Flip(horizontalInput);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJump = true;
        }
    }

    // All physics calculation should happen in Fixed Update
    private void FixedUpdate()
    {
        // Apply actual movement data to the rigidbody
        float horizontalMovement = horizontalInput * moveSpeed;
        playerRb.linearVelocity = new Vector2(horizontalMovement, playerRb.linearVelocityY);

        if (IsGrounded() && isJump)
        {
            playerRb.AddForce(new(0, jumpForce));
            isJump = false;
        }
    }

    private bool IsGrounded()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundPoint.position, groundRadius, groundLayers);
        for (int i = 0; i < colliders.Length; i++)
        {
            // Make sure to always ignore the player gameobject
            if (colliders[i].gameObject != this.gameObject)
            {
                return true;
            }
        }
        return false;
    }

    private void Flip(float movement)
    {
        // We will only flip if:
        // 1. We are moving to the right and we are not facing right
        // 2. We are moving to the left and we are not facing left
        if (movement > 0 && !isFacingRight ||
            movement < 0 && isFacingRight)
        {
            // Toggle the boolean
            isFacingRight = !isFacingRight;
            // Decide how you want to flip the character. you can change its scale or flip sprite
            spriteRenderer.flipX = !isFacingRight;
        }
    }

}
