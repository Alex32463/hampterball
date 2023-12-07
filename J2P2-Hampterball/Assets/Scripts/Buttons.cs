using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    private void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
    public void GoToGame()
    {
        SceneManager.LoadScene("Main");
    }
    public void RetryButton()
    {
        SceneManager.LoadScene("Main");
    }
    public void MainMenu()
    {
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
    public void LeaveGame()
    {
        Application.Quit();
    }
}
