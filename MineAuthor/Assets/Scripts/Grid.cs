using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    class Grid
    {

        #region Fields
        public int width;
        public int height;
        public Cell[][] cells;
        #endregion

        
        #region Constructor
        public Grid(int width, int height, Cell[][] cells)
        {
            this.width = width;
            this.height = height;
            this.cells = cells;
        }
        #endregion

        #region  Methods

        public String toString() {
            string current = "";
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Cell currentCell = cells[i][j];
                    if (currentCell.IsBomb)
                    {
                        current += "x";
                    }
                    else {
                        current += currentCell.AdjacentBomb;
                    }
                }
                current += "\n";
            }
            return current;
        }
        #endregion

    }
}
