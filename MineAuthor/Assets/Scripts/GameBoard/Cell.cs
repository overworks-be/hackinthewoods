﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    public class Cell
    {

        #region Fields
        private Boolean isBomb;
        private int adjacentBomb;
        private bool isRevealed;
        #endregion




        #region Constructor
        public Cell()
        {
            this.isBomb = false;
            this.adjacentBomb = 0;
            this.isRevealed = false; 
        }
        #endregion

        #region Properties
        public bool IsRevealead
        {
            get { return isRevealed; }
            set { isRevealed = value; }
        }

        public Boolean IsBomb
        {
            get { return isBomb; }
            set { isBomb = value; }
        }

        public int AdjacentBomb
        {
            get { return adjacentBomb; }
            set { adjacentBomb = value; }
        }
        #endregion

        #region Methods
        public String toString()
        {
            if (isBomb)
            {
                return "Bomb";
            }
            else
            {
                return "adjacentbomb: " + adjacentBomb;
            }
        }
        #endregion
    }
}
