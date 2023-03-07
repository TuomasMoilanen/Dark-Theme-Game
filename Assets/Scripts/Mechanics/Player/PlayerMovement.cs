using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables
    [Header("Player's static attributes")]
    [SerializeField]
    [Tooltip("Players Rigid body.")]
    Rigidbody2D rb; // Players Rigid body

    [SerializeField]
    [Tooltip("Defines player's movement speed.")]
    private float movSpeed; // Defines player's movement speed

    [SerializeField]
    [Tooltip("Defines the force for jump attribute.")]
    private float jumpForce; // Defines the force for jump attribute

    [SerializeField]
    [Tooltip("Status if player is grounded.")]
    private bool isGrounded; // Status if player is grounded

    private Animator animator;
    // [SerializeField]
    // private Animation anim;

    // ----------------------------------I   I---------------------------------- \\

    [Header("Jump / Fall multipliers")]
    [SerializeField]
    [Tooltip("How fast players fall speed picks up.")]
    private float fallMultiplier; // How fast players fall speed picks up
    [SerializeField] private AudioSource jumpSFX;

    [SerializeField]
    [Tooltip("Multiplier on how much player jumps on quick input.")]
    private float lowJumpMultiplier = 2f; // Multiplier on how much player jumps on quick input

    // ----------------------------------I   I---------------------------------- \\

    [Header("Ground check")]
    [SerializeField]
    [Tooltip("Checks grounds position and determines if \"isGrounded\".")]
    private Transform groundCheckPosition; // Checks grounds position and determines if "isGrounded"

    [SerializeField]
    [Tooltip("Determines the size of the radious to check if grounded.")]
    private float groundCheckRadius; // Determines the size of the radious to check if grounded

    [SerializeField]
    [Tooltip("Creates Gizmo on unity to show the check layer.")]
    private LayerMask groundCheckLayer; // Creates Gizmo on unity to show the check layer
    private Color groundCheckGizmoColor = new Color(0f, 0.5f, 0f, 0.5f); // Creates a color for the gizmo

    #endregion


    private void Awake()
    {
        animator = GetComponent<Animator>();

    }
    void Update()
    {
        #region Ground Check
        if (Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer)) // Gizmo to check "ground" layer
        {
            isGrounded = true;  // Player is touching ground
        }
        else
        {
            isGrounded = false; // Player is not touching ground
        }


        #endregion

        #region Movement & Jump

        // Moving code --------------------------------------
        var movement = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movSpeed;
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetBool("walking", true);
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("walking", true);
        }
        if (Input.GetAxisRaw("Horizontal") == 0 || isGrounded == false)
        {
            animator.SetBool("walking", false);
        }

        // Jump code --------------------------------------

        if (Input.GetButtonDown("Jump") && isGrounded) // Gets keyboard input from 'unity input manager' and translates it into players transform attributes,
        {                                              // to make player model move up and down
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpSFX.Play();
        }
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics.gravity * (fallMultiplier - 1) * Time.deltaTime;
            animator.SetBool("falling", true);

        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;

        }
        if (isGrounded == true)
        {
            animator.SetBool("jumping", false);
            animator.SetBool("falling", false);
        }

        if (rb.velocity.y > 0.2 && !isGrounded)
        {
            animator.SetBool("jumping", true);
        }

    }
    private void OnDrawGizmos()
    {

        Gizmos.color = groundCheckGizmoColor;

        Gizmos.DrawSphere(groundCheckPosition.position, groundCheckRadius); // Draws a gizmo for the groundCheck area
    }
    #endregion
}
