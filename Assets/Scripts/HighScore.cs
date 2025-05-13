using UnityEngine;
using TMPro;

public class SpeedrunTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI highscoreText;

    private float timeElapsed = 0f;
    private bool isRunning = true;

    void Start()
    {
        // Load and show saved highscore
        float savedHighscore = PlayerPrefs.GetFloat("Highscore", 0f);
        highscoreText.text = "Highscore: " + savedHighscore.ToString("F2") + "s";
    }

    void Update()
    {
        if (isRunning)
        {
            timeElapsed += Time.deltaTime;
            timerText.text = "Time: " + timeElapsed.ToString("F2") + "s";
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

        float savedHighscore = PlayerPrefs.GetFloat("Highscore", 0f);
        if (timeElapsed > savedHighscore)
        {
            // Only save if new time is better
            PlayerPrefs.SetFloat("Highscore", timeElapsed);
            PlayerPrefs.Save();
        }

        // Show updated highscore (even if unchanged)
        float currentHighscore = PlayerPrefs.GetFloat("Highscore", 0f);
        highscoreText.text = "Highscore: " + currentHighscore.ToString("F2") + "s";
    }
}
