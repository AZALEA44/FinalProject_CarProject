using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   
    public void onePlayer()
    {
        SceneManager.LoadScene("1player"); 
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void twoPlayer()
    {
        SceneManager.LoadScene("2player");
    }

    public void History()
    {
        SceneManager.LoadScene("PlayHistory"); 
    }

    public void Setting()
    {
        SceneManager.LoadScene("Setting");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }


    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; 
#else
            Application.Quit(); // Quit the game in a build
#endif
    }
}
