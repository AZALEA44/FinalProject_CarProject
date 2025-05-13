using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartOnKey : MonoBehaviour
{
    public bool canRestart = false;

    void Update()
    {
        if (canRestart && Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f; // Unpause
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
