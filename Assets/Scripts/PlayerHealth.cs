using UnityEngine;
using TMPro;  // Import TextMeshPro namespace

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;

    // Reference to the TextMeshProUGUI component to display HP
    public TextMeshProUGUI healthText;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    // Call this function to reduce HP when the player takes damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();
        Debug.Log("Player HP: " + currentHealth);

        // Check if the player's HP reaches 0 and handle death
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Update the UI with the current health
    private void UpdateHealthUI()
    {
        healthText.text = "HP: " + currentHealth;
    }

    // Handle player death
    private void Die()
    {
        Debug.Log("Player is dead!");
        // You can add more death logic here, like disabling player controls, playing a death animation, etc.
    }
}
