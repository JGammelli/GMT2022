using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int gridWidth, gridHeight;
    [SerializeField] private float gridCellSize;
    private int[,] gridArray;

    [SerializeField] private 


    private void Start()
    {
        GenerateGrid();
    }


    private void GenerateGrid()
    {
        gridArray = new int[gridWidth, gridHeight];


        for (int w = 0; w < gridWidth; w++)
        {
            for (int h = 0; h < gridHeight; h++)
            {
                Debug.Log(w + ", " + h);
            }
        }
    }

    private Vector3 GetGridWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * gridCellSize;
    }

}
