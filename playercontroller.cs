using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float gravity = 9.81f;

    private CharacterController controller;
    private Vector3 moveDirection;
    private bool isJumping;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction
        Vector3 horizontalMovement = transform.right * horizontalInput;
        Vector3 verticalMovement = transform.forward * verticalInput;
        moveDirection = (horizontalMovement + verticalMovement).normalized * moveSpeed;

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

        // Move the player
        controller.Move(moveDirection * Time.deltaTime);
    }
}
