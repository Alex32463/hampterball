using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void GoToGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void LeaveGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
