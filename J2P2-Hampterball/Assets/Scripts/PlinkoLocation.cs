using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlinkoLocation : MonoBehaviour
{
    //preset locations for the hamster to start falling
    List<Vector3> vector3List = new List<Vector3>
    {
        new Vector3(-13f, 7.5f, 0f),
        new Vector3(13f, 7.5f, 0f),
        new Vector3(5.8f, 7.5f, 0f),
        new Vector3(-5.9f, 7.5f, 0),
        new Vector3(-0.9f, 7.5f, 0f)
    };

    void Start()
    {
        //random integer that indexes the list on which location to choose where to fall
        int rng = UnityEngine.Random.Range(0, 5);
        transform.position = vector3List[rng];
    }

    void Update()
    {
        //makes the scene load the gameover scene if the player watches the full animation which takes 6 seconds and prevents softlocks
        StartCoroutine(ToGameOver());
    }

    IEnumerator ToGameOver()
    {
        //waits 6 seconds
        yield return new WaitForSeconds(6);
        //loads gameover scene
        GameOverScene(SceneManager.LoadScene);
        
    }
    
    //
    public void GameOverScene(Action<string, LoadSceneMode> loadScene)
    {
        SceneManager.LoadScene("GameOver");
    }
}
