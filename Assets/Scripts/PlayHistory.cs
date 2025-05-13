using TMPro;
using UnityEngine;

public class PlayHistory : MonoBehaviour
{
    int HighSCoinSample = 0;
    float HighSTimeSample = 0;

    [SerializeField] TextMeshProUGUI HighSCoinText;
    [SerializeField] TextMeshProUGUI HighSTimeText;

    void Start()
    {
        // Load saved high score data
        HighSCoinSample = PlayerPrefs.GetInt("HighScoreCoins", 0);
        HighSTimeSample = PlayerPrefs.GetFloat("Highscore", 0f);
        UpdateText();
    }

    void UpdateText()
    {
        if (HighSTimeSample <= 0)
        {
            HighSCoinText.text = "Coin : - ";
            HighSTimeText.text = "Time : - sec.";
        }
        else
        {
            HighSCoinText.text = $"Coin : {HighSCoinSample}";
            HighSTimeText.text = $"Time : {HighSTimeSample:F2} sec.";
        }
    }
}
