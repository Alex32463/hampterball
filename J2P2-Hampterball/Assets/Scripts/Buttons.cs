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
        SceneManager.LoadScene("MainMenu");
    }
    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void LeaveGame()
    {
        Application.Quit();
    }
}
