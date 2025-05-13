using TMPro;
using UnityEngine;

public class PlayHistory : MonoBehaviour
{
    int POneHighSCoinSample = 0;
    int PTwoHighSCoinSample = 0;
    float POneHighSTimeSample = 0;
    float PTwoHighSTimeSample = 0;
    [SerializeField] TextMeshProUGUI POneHighSCoinText;
    [SerializeField] TextMeshProUGUI PTwoHighSCoinText;
    [SerializeField] TextMeshProUGUI POneHighSTimeText;
    [SerializeField] TextMeshProUGUI PTwoHighSTimeText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        POneHighSCoinSample = 8;// PlayerPrefs.GetInt("Coin", 0);
        PTwoHighSCoinSample = 8;
        POneHighSTimeSample = PlayerPrefs.GetFloat("Highscore", 0f);
        PTwoHighSTimeSample = 4;
        UpdateText();
    }
    void UpdateText()
    {
        //HightScore
        //Player1
        if (POneHighSTimeSample <= 0)
        {
            POneHighSCoinText.text = "Coin : - ";
            POneHighSTimeText.text = "Time : - sec.";
        }
        else
        {
            POneHighSCoinText.text = $"Coin : {POneHighSCoinSample.ToString()}";
            POneHighSTimeText.text = $"Time : {POneHighSTimeSample.ToString("F2")} sec.";
        }
        //Player2
        if (PTwoHighSTimeSample <= 0)
        {
            PTwoHighSCoinText.text = "Coin : - ";
            PTwoHighSTimeText.text = "Time : - sec.";
        }
        else
        {
            PTwoHighSCoinText.text = $"Coin : {PTwoHighSCoinSample.ToString()}";
            PTwoHighSTimeText.text = $"Time : {PTwoHighSTimeSample.ToString("F2")} sec.";
        }
    }
}
