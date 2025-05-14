using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour
{
    private bool isMuted;

    
    public void ToggleMute()
    {
        isMuted = !AudioListener.pause;
        AudioListener.pause = isMuted;

        PlayerPrefs.SetInt("Muted", isMuted ? 1 : 0);
        PlayerPrefs.Save();
    }
}
