using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMotor : MonoBehaviour
{
    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void Move(Vector3 direction, float speed)
    {
        Vector3 move = direction * speed * Time.deltaTime;
        characterController.Move(move);
    }

    public void ApplyGravity(float gravity)
    {
        if (!characterController.isGrounded)
        {
            Vector3 gravityVector = new Vector3(0, gravity * Time.deltaTime, 0);
            characterController.Move(gravityVector);
        }
    }
}
