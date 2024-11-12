using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void UpdateMovementAnimation(float speed)
    {
        animator.SetFloat("Speed", speed);
    }

    public void PlayJumpAnimation()
    {
        animator.SetTrigger("Jump");
    }
}
