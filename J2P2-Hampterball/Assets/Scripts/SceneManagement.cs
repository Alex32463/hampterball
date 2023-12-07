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
        //Sets the gameObjects position to be positioned under the level
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, -4, gameObject.transform.position.z);
        player = FindObjectOfType<Movement>().gameObject; // Searches For Player GameObject
    }

    void Update()
    {
        //if the player isn't null
        if (player != null)
        {
            // If the players position.y is lower than the gameObjects position.y then load the scene (HamsterPlinko)
            if (player.transform.position.y < gameObject.transform.position.y)
            {
                PlinkoScene(SceneManager.LoadScene); // Grabs HamsterPlinko scene
            }
        }
    }
    // Grabs all the information of HamsterPlinko Scene
    public void PlinkoScene(Action<string, LoadSceneMode> loadScene)
    {
        SceneManager.LoadScene("HamsterPlinko");
    }
}
