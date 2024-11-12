using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float sprintMultiplier = 1.5f;
    public float jumpForce = 5f;
    public float gravity = -9.81f;

    private PlayerInput playerInput;
    private PlayerMotor playerMotor;
    private PlayerStats playerStats;
    private PlayerAnimator playerAnimator;

    private bool isSprinting;

    private void Awake()
    {
        playerInput = GameManager.Instance.GetBehaviourFromMeOrChildren<PlayerInput>(transform);
        playerMotor = GameManager.Instance.GetBehaviourFromMeOrChildren<PlayerMotor>(transform);
        playerStats = GameManager.Instance.GetBehaviourFromMeOrChildren<PlayerStats>(transform);
        playerAnimator = GameManager.Instance.GetBehaviourFromMeOrChildren<PlayerAnimator>(transform);
    }

    private void Update()
    {   
        HandleMovement();
        HandleSprint();
        HandleJump();
    }

    private void HandleMovement()
    {
        Vector2 inputDirection = playerInput.GetMovementInput();
        Vector3 moveDirection = new Vector3(inputDirection.x, 0, inputDirection.y).normalized;

        float speed = isSprinting ? movementSpeed * sprintMultiplier : movementSpeed;
        playerMotor.Move(moveDirection, speed);
        playerAnimator.UpdateMovementAnimation(moveDirection.magnitude);
    }

    private void HandleSprint()
    {
        if (playerInput.IsSprinting() && playerStats.HasStamina())
        {
            isSprinting = true;
            playerStats.DecreaseStamina();
        }
        else
        {
            isSprinting = false;
        }
    }

    private void HandleJump()
    {
        if (playerInput.IsJumping() && playerStats.HasStamina())
        {
            playerMotor.ApplyGravity(gravity);
            playerAnimator.PlayJumpAnimation();
        }
    }
}
