using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public PlayerStats stats;

    public Slider hpSlider;
    public Slider staminaSlider;

    void Start()
    {
        if (stats != null)
        {
            hpSlider.maxValue = stats.maxHealth;
            hpSlider.value = stats.currentHealth;

            staminaSlider.maxValue = stats.maxStamina;
            staminaSlider.value = stats.currentStamina;
        }
    }

    void Update()
    {
        if (stats == null) return;

        hpSlider.value = stats.currentHealth;
        staminaSlider.value = stats.currentStamina;
    }
}
