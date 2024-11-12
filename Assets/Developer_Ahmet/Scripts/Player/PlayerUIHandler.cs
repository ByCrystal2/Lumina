using UnityEngine;
using UnityEngine.UI;

public class PlayerUIHandler : MonoBehaviour
{
    public Slider healthSlider;
    public Slider staminaSlider;

    private PlayerStats playerStats;

    private void Awake()
    {
        playerStats = GetComponent<PlayerStats>();
    }

    private void Update()
    {
        UpdateHealthUI();
        UpdateStaminaUI();
    }

    private void UpdateHealthUI()
    {
        healthSlider.value = playerStats.currentHealth / playerStats.maxHealth;
    }

    private void UpdateStaminaUI()
    {
        staminaSlider.value = playerStats.currentStamina / playerStats.maxStamina;
    }
}
