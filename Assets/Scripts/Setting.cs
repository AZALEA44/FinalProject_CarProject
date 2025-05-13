using TMPro;
using UnityEngine;
using UnityEngine.UI;
public enum PlayerColor
{
    Red,
    Green,
    Blue,
    Yellow
}
public class Setting : MonoBehaviour
{
    public static Setting Instance;

     PlayerColor p1Color = PlayerColor.Red;
     PlayerColor p2Color = PlayerColor.Blue;

    public TMP_Dropdown p1Dropdown;
    public TMP_Dropdown p2Dropdown;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (p1Dropdown != null)
        {
            p1Dropdown.value = (int)p1Color;
            p1Dropdown.onValueChanged.AddListener(SetP1Color);
        }
        if (p2Dropdown != null)
        {
            p2Dropdown.value = (int)p2Color;
            p2Dropdown.onValueChanged.AddListener(SetP2Color);
        }
    }

    public void SetP1Color(int index)
    {
        p1Color = (PlayerColor)index;
    }

    public void SetP2Color(int index)
    {
        p2Color = (PlayerColor)index;
    }

    public Color GetColor(PlayerColor color)
    {
        return color switch
        {
            PlayerColor.Red => Color.red,
            PlayerColor.Green => Color.green,
            PlayerColor.Blue => Color.blue,
            PlayerColor.Yellow => Color.yellow,
            _ => Color.red
        };
    }

    public Color GetP1Color() => GetColor(p1Color);
    public Color GetP2Color() => GetColor(p2Color);
}
