using TMPro;
using UnityEngine;

public class PlayHistory : MonoBehaviour
{
    int HighSCoinSample = 0;
    float HighSTimeSample = 0;
    [SerializeField] TextMeshProUGUI HighSCoinText;
    [SerializeField] TextMeshProUGUI HighSTimeText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HighSCoinSample = 8;// PlayerPrefs.GetInt("Coin", 0);
        HighSTimeSample = PlayerPrefs.GetFloat("Highscore", 0f);
        UpdateText();
    }
    void UpdateText()
    {
        //HightScore
        //Player1
        if (HighSTimeSample <= 0)
        {
            HighSCoinText.text = "Coin : - ";
            HighSTimeText.text = "Time : - sec.";
        }
        else
        {
            HighSCoinText.text = $"Coin : {HighSCoinSample.ToString()}";
            HighSTimeText.text = $"Time : {HighSTimeSample.ToString("F2")} sec.";
        }
    }
}
