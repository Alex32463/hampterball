using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject[] levelChunks;
    [SerializeField] int courseWidth;
    [SerializeField] int initialGenerateAhead;
    [SerializeField] float tileSize = 2;
    [SerializeField] int generateDistance = 25;
    [SerializeField] int removeDistance = 10;
    ChunkSelfdestruction chunkSelfdestruction;
    private List<GameObject[]> levelTiles = new List<GameObject[]>();
    private int levelRowCount = 0;
    void Start()
    {
        GenerateStartingArea();
    }
    void Update()
    {
        float playerZ = player.transform.position.z;
        while (playerZ + generateDistance > levelRowCount * tileSize)
        {
            GenerateRow(levelRowCount);
            if (levelTiles.Count > 0 && playerZ - removeDistance > (levelTiles[0][0].transform.position.z / tileSize))
            {
                Debug.Log("if statement passed");
                DestroyRow(levelTiles[0]);
                levelTiles.RemoveAt(0);
            }
        }
    }
    private void GenerateStartingArea()
    {
        for (int x = 0; x < courseWidth + initialGenerateAhead; x++)
        {
            GenerateRow(x);
        }
    }
    private void GenerateRow(int x)
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
    }
}
