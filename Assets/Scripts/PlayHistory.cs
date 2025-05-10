using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class NewMonoBehaviourScript : MonoBehaviour
{
    int POneCoinSample = 0;
    int PTwoCoinSample = 0;
    float POneDistanceSample = 0;
    float PTwoDistanceSample = 0;
    [SerializeField] TextMeshProUGUI POneCoinText;
    [SerializeField] TextMeshProUGUI PTwoCoinText;
    [SerializeField] TextMeshProUGUI POneDistanceText;
    [SerializeField] TextMeshProUGUI PTwoDistanceText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        POneCoinSample = 1;
        PTwoCoinSample = 2;
        POneDistanceSample = 3;
        PTwoDistanceSample = 0;
        UpdateText();
    }
    void UpdateText()
    {
        //Player1
        POneCoinText.text = $"Coin : {POneCoinSample.ToString()}";
        POneDistanceText.text = $"Distance : {POneDistanceSample.ToString()} m";
        //Player2
        if ( PTwoDistanceSample <= 0)
        {
            PTwoCoinText.text = "Coin : - ";
            PTwoDistanceText.text = "Distance : - m";
        }
        else
        {
            PTwoCoinText.text = $"Coin : {PTwoCoinSample.ToString()}";
            PTwoDistanceText.text = $"Distance : {PTwoDistanceSample.ToString()} m";
        }
    }
}
