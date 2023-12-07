using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlinkoLocation : MonoBehaviour
{

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
        int rng = UnityEngine.Random.Range(0, 5);
        transform.position = vector3List[rng];
    }

    void Update()
    {
        StartCoroutine(ToGameOver());
    }

    IEnumerator ToGameOver()
    {
        yield return new WaitForSeconds(6);
        GameOverScene(SceneManager.LoadScene);
        
    }
    public void GameOverScene(Action<string, LoadSceneMode> loadScene)
    {
        SceneManager.LoadScene("GameOver");
    }
}
