using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    public class Grid
    {
        #region Fields
        private int width;
        private int height;
        private Cell[][] cells;
        #endregion

        #region Properties
        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public Cell[][] Cells
        {
            get { return cells; }
            set { cells = value; }
        }
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
                    else if(currentCell.AdjacentBomb == 0)
                    {
                        current += ".";
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
