using UnityEngine;
using TMPro;

public class CoinCollector : MonoBehaviour
{
    public static int coinCount = 0;
    public TextMeshProUGUI coinText;

    void Update()
    {
        coinText.text = "Coins: " + coinCount;
    }
}
