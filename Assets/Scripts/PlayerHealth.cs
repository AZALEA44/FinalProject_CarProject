using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;

    public TextMeshProUGUI healthText;

    // ?? Add this reference
    public HighScore speedrunTimer;

    void Start()
    {
        currentHealth = maxHealth;
        CoinCollector.coinCount = 0;
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

        SoundEffectManager.Instance.Play("Dead");

        // Stop timer
        if (speedrunTimer != null)
            speedrunTimer.StopAndSaveTime();

        // Save high coin score
        int currentCoins = CoinCollector.coinCount;
        int previousHigh = PlayerPrefs.GetInt("HighScoreCoins", 0);
        if (currentCoins > previousHigh)
        {
            PlayerPrefs.SetInt("HighScoreCoins", currentCoins);
            PlayerPrefs.Save();
        }
        

        Time.timeScale = 0f;
        SceneManager.LoadScene("Dead");
    }


}
