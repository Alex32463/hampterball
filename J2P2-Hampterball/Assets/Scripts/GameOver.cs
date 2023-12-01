using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneManagement : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, -4, gameObject.transform.position.z);
        player = FindObjectOfType<Movement>().gameObject; // Zoekt Player GameObject
    }

    void Update()
    {
        if (player != null)
        {
            // Als de Player lager is dan de gameObject (SceneManagement) ga naar aangegeven scene.
            if (player.transform.position.y < gameObject.transform.position.y)
            {
                GameOverScene(SceneManager.LoadScene); // Pakt GameOver scene
            }
        }
    }
    // Pakt alle informatie voor GameOver Scene
    public void GameOverScene(Action<string, LoadSceneMode> loadScene)
    {
        SceneManager.LoadScene("GameOver");
    }
}
