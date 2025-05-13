using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healAmount = 1;  // Amount of HP to restore

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Entered with: " + other.name);

        // Check if the object that collided is the player
        if (other.CompareTag("Player")) // Ensure the player object has the "Player" tag
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                // Heal the player by the specified amount
                playerHealth.Heal(healAmount);
                SoundEffectManager.Instance.Play("HP");

                // Log the success
                Debug.Log("Healing player: " + healAmount);

                // Destroy the item after being picked up
                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("PlayerHealth component not found on " + other.name);
            }
        }
        else
        {
            Debug.LogWarning("The object that triggered is not the player.");
        }
    }
}
