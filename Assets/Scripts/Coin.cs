using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CoinCollector.coinCount++; // static counter
            SoundEffectManager.Instance.Play("Coin");
            Destroy(gameObject); // remove coin
        }
    }
}
