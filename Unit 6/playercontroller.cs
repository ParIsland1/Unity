using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float gravity = 9.81f;
    [SerializeField] private float crouchSpeed = 2.5f;
    [SerializeField] private float crouchHeight = 0.5f;
    [SerializeField] private float sprintSpeed = 8f;
    [SerializeField] private float staminaMax = 100f;
    [SerializeField] private float sprintStaminaCost = 10f;

    private CharacterController controller;
    private Vector3 moveDirection;
    private bool isJumping;
    private bool isCrouching;
    private float originalHeight;
    private float stamina;
    private float rotationX = 0f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        originalHeight = controller.height;
        stamina = staminaMax;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction
        Vector3 horizontalMovement = transform.right * horizontalInput;
        Vector3 verticalMovement = transform.forward * verticalInput;

        // Adjust speed based on crouching and sprinting
        float currentSpeed = isCrouching ? moveSpeed / crouchSpeed : (Input.GetKey(KeyCode.LeftShift) && stamina > 0 ? sprintSpeed : moveSpeed);

        moveDirection = (horizontalMovement + verticalMovement).normalized * currentSpeed;

        // Check for crouch input
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            ToggleCrouch();
        }

        // Check for jumping input
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            isJumping = true;
        }

        // Apply gravity
        if (!controller.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Apply jump
        if (isJumping)
        {
            moveDirection.y = jumpForce;
            isJumping = false;
        }

        // Handle sprinting and stamina
        if (Input.GetKey(KeyCode.LeftShift) && stamina > 0)
        {
            stamina -= sprintStaminaCost * Time.deltaTime;
        }
        else if (stamina < staminaMax)
        {
            stamina += Time.deltaTime;
        }

        // Move the player
        controller.Move(moveDirection * Time.deltaTime);

        // Handle smooth rotation based on mouse movement
        float mouseX = Input.GetAxis("Mouse X");
        rotationX -= mouseX;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); // Clamp the vertical rotation
        transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
    }

    private void ToggleCrouch()
    {
        isCrouching = !isCrouching;

        if (isCrouching)
        {
            controller.height = crouchHeight;
        }
        else
        {
            controller.height = originalHeight;
        }
    }
}

