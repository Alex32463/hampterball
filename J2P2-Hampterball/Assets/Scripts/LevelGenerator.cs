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
    [SerializeField] float floorObstacleAmount = 25;
    [SerializeField] float sideObstacleAmount = 25;
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
        GenerateCourse();
    }
    private void GenerateStartingArea()
    {
        for (int x = 0; x < courseWidth * 6; x++)
        {
            GenerateRow(x);
        }
    }
    private void GenerateCourse()
    {
        if (playerPosition.position.x > levelRowCount + 25)
        {
            GenerateRow(levelRowCount);
        }
    }
    private void GenerateRow(int x)
    {
        for (int y = 0; y < courseWidth + 2; y++)
        {
            int obstacleOrNot = Random.Range(0, 100);
            if (y == 0 || y == courseWidth - 1 || x == 0)
            {
                if (obstacleOrNot < sideObstacleAmount && levelRowCount > 6)
                {
                    levelRow[y] = sideObstacles[Random.Range(0,(floorObstacles.Length - 1))];
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
                    levelRow[y] = floorObstacles[Random.Range(0,(floorObstacles.Length - 1))];
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
            Instantiate(levelRow[z], new Vector3(x * 2, 0, z * 2), Quaternion.identity);
        }
        levelRowCount++;
    }
}
