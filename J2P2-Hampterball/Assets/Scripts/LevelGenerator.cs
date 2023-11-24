using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] Transform playerPosition;
    [SerializeField] GameObject floorPlane;
    [SerializeField] GameObject[] floorObstacles;
    [SerializeField] GameObject sideWall;
    [SerializeField] GameObject[] sideObstacles;
    [SerializeField] int courseWidth;
    [SerializeField] int initialGenerateAhead;
    [SerializeField] float floorObstacleAmount = 25f;
    [SerializeField] float sideObstacleAmount = 25f;
    [SerializeField] float generateDistance = 25f;
    [SerializeField] float removeDistance = 10f;
    private List<GameObject[]> levelTiles = new List<GameObject[]>();
    private GameObject[] levelRow;
    private int levelRowCount = 0;
    void Start()
    {
        levelRow = new GameObject[courseWidth + 2];
        GenerateStartingArea();
    }
    void Update()
    {
        float playerZ = playerPosition.position.z;
        if (playerZ + generateDistance > levelRowCount * 2)
        {
            GenerateRow(levelRowCount);
        }
        if (levelTiles.Count > 0 && playerZ - removeDistance > (levelTiles[0][0].transform.position.x / 2))
        {
            DestroyRow(levelTiles[0]);
            levelTiles.RemoveAt(0);
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
        GameObject[] levelRow = new GameObject[courseWidth + 2];

        for (int y = 0; y < courseWidth + 2; y++)
        {
            int obstacleOrNot = Random.Range(0, 100);
            if (y == 0 || y == courseWidth - 1 || x == 0)
            {
                if (obstacleOrNot < sideObstacleAmount && levelRowCount > 6)
                {
                    levelRow[y] = sideObstacles[Random.Range(0, (floorObstacles.Length - 1))];
                }
                else
                {
                    levelRow[y] = sideWall;
                }
            }
            else
            {
                if (obstacleOrNot < floorObstacleAmount && levelRowCount > 6)
                {
                    levelRow[y] = floorObstacles[Random.Range(0, (floorObstacles.Length - 1))];
                }
                else
                {
                    levelRow[y] = floorPlane;
                }
            }
        }

        levelTiles.Add(levelRow);

        for (int z = 0; z < courseWidth; z++)
        {
            Instantiate(levelRow[z], new Vector3(z * 2, 0, x * 2), Quaternion.identity);
        }

        levelRowCount++;
    }
    private void DestroyRow(GameObject[] row)
    {
        foreach (GameObject block in row)
        {
            Destroy(block);
        }
    }
}
