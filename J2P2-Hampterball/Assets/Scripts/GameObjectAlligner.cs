using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class GameObjectAlligner : MonoBehaviour
{
    public int rowCount = 7; // Number of rows
    public int columnCount = 7; // Number of columns
    public float spacing = 6f; // Spacing between objects
    void Start()
    {
        AlignGrid();
    }
    void AlignGrid()
    {
        int childCount = transform.childCount;
        int currentChild = 0;

        for (int row = 0; row < rowCount; row++)
        {
            for (int col = 0; col < columnCount; col++)
            {
                if (currentChild < childCount)
                {
                    Transform child = transform.GetChild(currentChild);

                    float xPos = col * spacing;
                    float zPos = row * spacing;

                    child.position = new Vector3(xPos, 0f, zPos);

                    currentChild++;
                }
                else
                {
                    break;
                }
            }
        }
    }
}
