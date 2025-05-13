using UnityEngine;
using System.Collections;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional: persist across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void BoostTime(float speedMultiplier, float duration)
    {
        StopAllCoroutines();
        StartCoroutine(TimeBoostCoroutine(speedMultiplier, duration));
    }

    private IEnumerator TimeBoostCoroutine(float multiplier, float duration)
    {
        Time.timeScale = multiplier;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;

        yield return new WaitForSecondsRealtime(duration); // Use unscaled time!

        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
    }
}
