using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 GetMovementInput()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        return new Vector2(moveX, moveZ);
    }

    public bool IsSprinting()
    {
        return Input.GetKey(KeyCode.LeftShift); // Shift tu�u ile sprint
    }

    public bool IsJumping()
    {
        return Input.GetButtonDown("Jump"); // Jump tu�una bas�ld���nda
    }
}
