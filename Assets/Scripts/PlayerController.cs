using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the player
    public float jumpForce = 5f; // Jump force of the player
    public Transform groundCheck; // Transform to check if the player is on the ground
    public LayerMask groundLayer; // Layer to check for ground

    private Rigidbody rb; // Reference to the Rigidbody component
    private bool isGrounded; // Check if the player is on the ground

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        float moveX = Input.GetAxis("Horizontal"); // Get horizontal input
        float moveZ = Input.GetAxis("Vertical"); // Get vertical input
        Vector3 move = transform.right * moveX + transform.forward * moveZ; // Calculate movement direction
        Vector3 velocity = move * moveSpeed; // Calculate velocity
        velocity.y = rb.velocity.y; // Maintain the current vertical velocity
        rb.velocity = velocity; // Apply the velocity to the Rigidbody

        // Ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer); // Check if the player is on the ground

        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded) // Check if the jump button is pressed and the player is on the ground
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Apply jump force
        }
    }
}
