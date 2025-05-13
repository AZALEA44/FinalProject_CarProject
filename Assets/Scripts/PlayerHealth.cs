using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;

    public TextMeshProUGUI healthText;

    // ?? Add this reference
    public SpeedrunTimer speedrunTimer;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        healthText.text = "HP: " + currentHealth;
    }

    private void Die()
    {
        Debug.Log("Player is dead!");

        // Stop the timer and save the time
        FindObjectOfType<SpeedrunTimer>().StopAndSaveTime();

        // Pause game
        Time.timeScale = 0f;

        // Optional: show "Press R to restart"
        FindObjectOfType<RestartOnKey>().canRestart = true;
    }

}
