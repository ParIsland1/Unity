using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Adjustable movement speed
    [SerializeField] private float movementSpeed = 5.0f;

    // Adjustable jump height (force)
    [SerializeField] private float jumpForce = 8.0f;

    // CharacterController component reference
    private CharacterController controller;

    // Gravity value
    private float gravity = 9.81f;

    // Vertical movement velocity
    private float verticalVelocity = 0.0f;

    // Grounded check
    private bool isGrounded;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Check if the character is grounded
        isGrounded = controller.isGrounded;

        if (isGrounded)
        {
            // Calculate movement direction
            Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);

            // Apply movement speed
            moveDirection *= movementSpeed;

            // Handle jumping
            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = jumpForce;
            }
        }

        // Apply gravity to the vertical velocity
        verticalVelocity -= gravity * Time.deltaTime;

        // Ensure that the character doesn't continue moving upwards if not grounded
        if (!isGrounded)
        {
            verticalVelocity = Mathf.Max(verticalVelocity, -gravity);
        }

        // Update the character's vertical velocity
        Vector3 verticalMovement = new Vector3(0, verticalVelocity, 0);

        // Move the character
        controller.Move((moveDirection + verticalMovement) * Time.deltaTime);
    }
}
