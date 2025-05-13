using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI highscoreText;
    public float time = 0f;
    private bool isRunning = true;
    public float HighScoreCount;
    void Start()
    {
        //PlayerPrefs.SetFloat("Highscore", 0f);
        // Load and show saved highscore
        HighScoreCount = PlayerPrefs.GetFloat("Highscore", 0f);
        highscoreText.text = "Highscore: " + HighScoreCount.ToString("F2") + "s";
    }

    void Update()
    {
        if (isRunning)
        {
            time += Time.deltaTime;
            timerText.text = "Time: " + time.ToString("F2") + "s";
        }

        // Optional: Restart on R key
        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f;
            UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
            );
        }
    }

    public void StopAndSaveTime()
    {
        isRunning = false;

        HighScoreCount = PlayerPrefs.GetFloat("Highscore", 0f);
        if (time > HighScoreCount)
        {
            // Only save if new time is better
            PlayerPrefs.SetFloat("Highscore", time);
            PlayerPrefs.Save();
        }

        // Show updated highscore (even if unchanged)
        float currentHighscore = PlayerPrefs.GetFloat("Highscore", 0f);
        highscoreText.text = "Highscore: " + currentHighscore.ToString("F2") + "s";

    }
}
