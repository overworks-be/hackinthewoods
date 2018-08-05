using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.GameBoard
{
    public class GridEngine
    {
        public static Grid buildGrid(int width, int height, int[][] dataMap)
        {
            Cell[][] cells = new Cell[height][];
            for (int i = 0; i < height; i++)
            {
                cells[i] = new Cell[width];
            }

            populateCells(width, height, dataMap, cells);

            return new Grid(width, height, cells);
        }

        private static void populateCells(int width, int height, int[][] dataMap, Cell[][] cells)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Cell cell = new Cell();
                    if (dataMap[i][j] == 1)
                    {
                        cell.IsBomb = true;
                        setAdjacentMine(i, j, dataMap, width, height);
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

            cells[29][10].AdjacentBomb = -2;
            cells[29][11].AdjacentBomb = -2;

            cells[28][9].AdjacentBomb = -2;
            cells[28][10].AdjacentBomb = -2;
            cells[28][11].AdjacentBomb = -2;
            cells[28][12].AdjacentBomb = -2;
            cells[29][12].AdjacentBomb = -2;
            cells[30][12].AdjacentBomb = -2;
            cells[30][11].AdjacentBomb = -2;
            cells[30][10].AdjacentBomb = -2;
            cells[30][9].AdjacentBomb = -2;
            cells[29][9].AdjacentBomb = -2;

        }


        private static void setAdjacentMine(int i, int j, int[][] dataMap, int width, int height)
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


    }
}
