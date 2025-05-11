using UnityEngine;

public class DamageObject : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Check if the object collides with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Get the PlayerHealth component from the player GameObject
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                // Call the TakeDamage function to reduce the player's health by 1
                playerHealth.TakeDamage(1);

                // Optionally, destroy this object when the player loses health
                Destroy(gameObject);  // Destroys the object that this script is attached to
            }
        }
    }
}
