using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public static Setting Instance;
    bool isSoundOn = true;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public Toggle soundToggle;

    void Start()
    {
        soundToggle.isOn = Instance.isSoundOn;
        soundToggle.onValueChanged.AddListener(OnSoundToggleChanged);
    }

    void OnSoundToggleChanged(bool value)
    {
        Instance.isSoundOn = value;
    }
}
