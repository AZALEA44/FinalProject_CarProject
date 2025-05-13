using UnityEngine;

public class SpeedItem : MonoBehaviour
{
    [SerializeField] private GameObject pickupEffect;
    [SerializeField] private float speedMultiplier = 2f;
    [SerializeField] private float speedDuration = 3f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            

            // Boost time using the manager
            if (TimeManager.Instance != null)
            {
                TimeManager.Instance.BoostTime(speedMultiplier, speedDuration);
            }

            Destroy(gameObject); // Now it's safe to destroy
        }
    }
}
