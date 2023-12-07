using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    // Makes references to the gameobjects in the editor.
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject pauseButton;
    // If the player clicks on the button linked with "pause".
    public void Pause()
    {
        // Activates the pause menu panel.
        pauseMenu.SetActive(true);
        // Deactivates the pause button.
        pauseButton.SetActive(false);
        // Sets the timescale to 0 which puts the game on pause.
        Time.timeScale = 0f;
    }
    // If the player clicks on the button linked with "Resume".
    public void Resume()
    {
        // Deactivates the pause menu panel.
        pauseMenu.SetActive(false);
        // Activates the pause button
        pauseButton.SetActive(true);
        // Sets the timescale to 1 which resumes the game.
        Time.timeScale = 1f;
    }
}
