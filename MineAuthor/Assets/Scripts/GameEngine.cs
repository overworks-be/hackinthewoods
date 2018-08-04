using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Assets;
using System;

public class GameEngine : MonoBehaviour
{

    private Assets.Grid grid;
    private Cell[][] cells;
    private int width;
    private int height;
    public Vector2 cellSize;

    // Use this for initialization
    void Start()
    {
        this.buildGrid(5, 6, DataMap.map);
    }

    #region Grid Init

    private void buildGrid(int width, int height, int[][] dataMap)
    {
        this.width = width;
        this.height = height;
        cells = new Cell[height][];
        for (int i = 0; i < height; i++)
        {
            cells[i] = new Cell[width];
        }
        populateCells(dataMap);
        setGridCells();
    }

    private void setGridCells()
    {
        grid = new Assets.Grid(width, height, cells);
        Debug.Log(grid.toString());
    }

    private void populateCells(int[][] dataMap)
    {
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Cell cell = new Cell();
                if (dataMap[i][j] == 1)
                {
                    cell.IsBomb = true;
                    setAdjacentMine(dataMap, i, j);
                }
                cells[i][j] = cell;
            }
        }

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (dataMap[i][j] < 0)
                {
                    cells[i][j].AdjacentBomb = Math.Abs(dataMap[i][j]);
                }
            }
        }
    }

    private void setAdjacentMine(int[][] dataMap, int i, int j)
    {
        if (j + 1 <= width - 1)
        {
            if (dataMap[i][j + 1] != 1)
            {
                dataMap[i][j + 1]--;
            }
        }

        if (j - 1 >= 0)
        {
            if (dataMap[i][j - 1] != 1)
            {
                dataMap[i][j - 1]--;
            }
        }

        if (i + 1 <= height - 1)
        {
            if (dataMap[i + 1][j] != 1)
            {
                dataMap[i + 1][j]--;
            }

        }

        if (i + 1 <= height - 1 && j - 1 >= 0)
        {
            if (dataMap[i + 1][j - 1] != 1)
            {
                dataMap[i + 1][j - 1]--;
            }
        }

        if (i + 1 <= height - 1 && j + 1 <= width - 1)
        {
            if (dataMap[i + 1][j + 1] != 1)
            {
                dataMap[i + 1][j + 1]--;
            }
        }

        if (i - 1 >= 0)
        {
            if (dataMap[i - 1][j] != 1)
            {
                dataMap[i - 1][j]--;
            }
        }

        if (i - 1 >= 0 && j - 1 >= 0)
        {
            if (dataMap[i - 1][j - 1] != 1)
            {
                dataMap[i - 1][j - 1]--;
            }
        }

        if (i - 1 >= 0 && j + 1 <= width - 1)
        {
            if (dataMap[i - 1][j + 1] != 1)
            {
                dataMap[i - 1][j + 1]--;
            }
        }
    }

    #endregion

    internal Vector3 getPosition(int x, int y)
    {
        return new Vector3(x * cellSize.x, 0.0F, y * cellSize.y);
    }



    public int checkCell(float xF, float yF)
    {
        int x = (int)xF;
        int y = (int)yF;

        if (grid.cells[y][x].IsBomb)
        {
            Debug.Log("BOUM!");
            return -1;
        }
        else
        {
            Debug.Log("near bomb: " + grid.cells[y][x].AdjacentBomb);
            return grid.cells[y][x].AdjacentBomb;
        }
    }


    // Update is called once per frame
    void Update()
    {

    }




}
