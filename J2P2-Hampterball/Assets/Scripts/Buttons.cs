using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    private void Start()
    {
        // Add a sleep timeout so it never sleeps.
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
    public void GoToGame()
    {
        // If the button that has gotogame linked to it, and is pressed the scene will switch
        SceneManager.LoadScene("Main");
    }
    public void RetryButton()
    {
        SceneManager.LoadScene("Main");
    }
    public void MainMenu()
    {
        // When the player enters the main menu scene from the pause menu. The time is then set back to regular.
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
