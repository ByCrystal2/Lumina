using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    public float maxStamina = 100f;
    public float currentStamina;
    public float staminaDecreaseRate = 10f;
    public float staminaRecoveryRate = 5f;

    private void Start()
    {
        currentHealth = maxHealth;
        currentStamina = maxStamina;
    }

    private void Update()
    {
        RecoverStamina();
    }

    public bool HasStamina()
    {
        return currentStamina > 0;
    }

    public void DecreaseStamina()
    {
        currentStamina = Mathf.Max(0, currentStamina - staminaDecreaseRate * Time.deltaTime);
    }

    private void RecoverStamina()
    {
        if (currentStamina < maxStamina)
        {
            currentStamina += staminaRecoveryRate * Time.deltaTime;
        }
    }
}
