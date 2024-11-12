using UnityEngine;
public class Player : MonoBehaviour
{
    public PlayerInput playerInput;
    public PlayerMotor playerMotor;
    public PlayerMovement playerMovement;
    public PlayerStats playerStats;
    public PlayerAnimator playerAnimator;
    public PlayerUIHandler playerUIHandler;
    private void Awake()
    {
        playerInput = GameManager.Instance.GetBehaviourFromMeOrChildren<PlayerInput>(transform);
        playerMotor = GameManager.Instance.GetBehaviourFromMeOrChildren<PlayerMotor>(transform);
        playerMovement = GameManager.Instance.GetBehaviourFromMeOrChildren<PlayerMovement>(transform);
        playerStats = GameManager.Instance.GetBehaviourFromMeOrChildren<PlayerStats>(transform);
        playerAnimator = GameManager.Instance.GetBehaviourFromMeOrChildren<PlayerAnimator>(transform);
        playerUIHandler = GameManager.Instance.GetBehaviourFromMeOrChildren<PlayerUIHandler>(transform);
    }
}
