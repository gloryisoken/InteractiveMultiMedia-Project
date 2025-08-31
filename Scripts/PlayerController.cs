using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movement speed of the monkey
    public float moveSpeed = 5f;

    // Jump force for the monkey
    public float jumpForce = 5f;

    // Reference to the Rigidbody component
    private Rigidbody rb;

    // Flag to check if the player is on the ground
    private bool isGrounded;

    void Start()
    {
        // Get the Rigidbody attached to this GameObject
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // --- MOVEMENT ---
        // Get horizontal (A/D) and vertical (W/S) input
        float moveX = Input.GetAxis("Horizontal"); // A/D
        float moveZ = Input.GetAxis("Vertical");   // W/S

        // Get camera forward and right directions
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        // Flatten them on the XZ plane
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        // Movement relative to camera
        Vector3 movement = forward * moveZ + right * moveX;

        // Apply movement while keeping current Y velocity (gravity, jump)
        rb.linearVelocity = movement * moveSpeed + Vector3.up * rb.linearVelocity.y;

        // --- JUMP ---
        // Press Space to jump only if on the ground
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    // This function checks if the player touches the ground
    void OnCollisionEnter(Collision collision)
    {
        // If we hit something tagged "Ground", we can jump again
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // When we leave the ground, can't jump
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
