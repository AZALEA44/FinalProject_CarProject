using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CoinCollector.coinCount++; // static counter
            Destroy(gameObject); // remove coin
        }
    }
}
