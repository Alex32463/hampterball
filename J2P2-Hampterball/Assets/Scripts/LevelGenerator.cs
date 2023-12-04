using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject player;            //the gameobject of the player is being kept track of to have the level instantiate and de-instantiate in the right places
    [SerializeField] GameObject[] levelChunks;     //collection of prefabs the level is built out of
    [SerializeField] int courseWidth;              //the with in number of prefabs side to side
    [SerializeField] int initialGenerateAhead;     //when the level first renders the level generator generates a starting area, this variable decides the length of that starting area
    [SerializeField] float tileSize = 2;           //the size of the prefab it was 2 for testing purposes but if things go according to plan when writing this it will be more
    [SerializeField] int generateDistance = 25;    //the distance the level generates ahead of the player
    [SerializeField] int removeDistance = 10;      //the distance the level gets removed behind of the player
    private List<GameObject[]> levelTiles = new List<GameObject[]>(); //list of all game objects the level is built out of
    private int levelRowCount = 0;                 //this variable keeps track of how far the level has generated
    void Start()
    {
        GenerateStartingArea(); //generates the starting area
    }
    void Update()
    {
        float playerZ = player.transform.position.z; //registers the location of the player on the z axis
        while (playerZ + generateDistance > levelRowCount * tileSize) //checks if there are non-generated rows in the generate distance and loops till its caught up
        {
            GenerateRow(levelRowCount); //generates a row
            if (levelTiles.Count > 0 && playerZ - removeDistance > (levelTiles[0][0].transform.position.z / tileSize)) //checks if there are generated rows in the remove distance
            {
                DestroyRow(levelTiles[0]); //desroys a row at the last index in the list
            }
        }
    }
    private void GenerateStartingArea()
    {
        for (int x = 0; x < courseWidth + initialGenerateAhead; x++) //the loops for the course with and the initialGeneratAhead distanse
        {
            GenerateRow(x); //generates a row for the starting area
        }
    }
    private void GenerateRow(int x) //
    {
        GameObject[] levelRow = new GameObject[courseWidth];

        for (int y = 0; y < courseWidth; y++)
        {
            GameObject prefabToBeUsed = levelChunks[UnityEngine.Random.Range(0, levelChunks.Length)];
            GameObject obj = Instantiate(prefabToBeUsed, new Vector3(y * tileSize, 0, x * tileSize), Quaternion.identity);
            levelRow[y] = obj;
        }
        this.levelTiles.Add(levelRow);
        levelRowCount++;
    }
    private void DestroyRow(GameObject[] row)
    {
        Debug.Log("Destroy row");
        foreach (GameObject Block in row)
        {
            Destroy(Block);
            Debug.Log("Destroy block");
        }
        levelTiles.RemoveAt(0);
    }
}
