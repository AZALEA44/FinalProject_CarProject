using TMPro;
using UnityEngine;

public class PlayHistory : MonoBehaviour
{
    int POneCoinSample = 0;
    int PTwoCoinSample = 0;
    float POneTimeSample = 0;
    float PTwoTimeSample = 0;
    int POneHightSCoinSample = 0;
    int PTwoHightSCoinSample = 0;
    float POneHightSTimeSample = 0;
    float PTwoHightSTimeSample = 0;
    [SerializeField] TextMeshProUGUI POneCoinText;
    [SerializeField] TextMeshProUGUI PTwoCoinText;
    [SerializeField] TextMeshProUGUI POneTimeText;
    [SerializeField] TextMeshProUGUI PTwoTimeText;
    [SerializeField] TextMeshProUGUI POneHightSCoinText;
    [SerializeField] TextMeshProUGUI PTwoHightSCoinText;
    [SerializeField] TextMeshProUGUI POneHightSTimeText;
    [SerializeField] TextMeshProUGUI PTwoHightSTimeText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        POneCoinSample = 2;
        PTwoCoinSample = 4;
        POneTimeSample = 1;
        PTwoTimeSample = 2;
        POneHightSCoinSample = 7;
        PTwoHightSCoinSample = 8;
        POneHightSTimeSample = 3;
        PTwoHightSTimeSample = 4;
        UpdateText();
    }
    void UpdateText()
    {
        //LastGame
        //Player1
        if (POneTimeSample <= 0)
        {
            POneCoinText.text = "Coin : - ";
            POneTimeText.text = "Time : - sec.";
        }
        else
        {
            POneCoinText.text = $"Coin : {POneCoinSample.ToString()}";
            POneTimeText.text = $"Time : {POneTimeSample.ToString()} sec.";
        }
        //Player2
        if ( PTwoTimeSample <= 0)
        {
            PTwoCoinText.text = "Coin : - ";
            PTwoTimeText.text = "Time : - sec.";
        }
        else
        {
            PTwoCoinText.text = $"Coin : {PTwoCoinSample.ToString()}";
            PTwoTimeText.text = $"Time : {PTwoTimeSample.ToString()} sec.";
        }
        //HightScore
        //Player1
        if (POneHightSTimeSample <= 0)
        {
            POneHightSCoinText.text = "Coin : - ";
            POneHightSTimeText.text = "Time : - sec.";
        }
        else
        {
            POneHightSCoinText.text = $"Coin : {POneHightSCoinSample.ToString()}";
            POneHightSTimeText.text = $"Time : {POneHightSTimeSample.ToString()} sec.";
        }
        //Player2
        if (PTwoTimeSample <= 0)
        {
            PTwoHightSCoinText.text = "Coin : - ";
            PTwoHightSTimeText.text = "Time : - sec.";
        }
        else
        {
            PTwoHightSCoinText.text = $"Coin : {PTwoHightSCoinSample.ToString()}";
            PTwoHightSTimeText.text = $"Time : {PTwoHightSTimeSample.ToString()} sec.";
        }
    }
}
