using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    class Cell
    {

        #region Fields
        private Boolean isBomb = false;
        private int adjacentBomb = 0;
        #endregion

        #region Properties
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
        public String toString() {
            if (isBomb) {
                return "Bomb";
            } else
            {
                return "adjacentbomb: " + adjacentBomb;
            }
        }
        #endregion
    }
}
