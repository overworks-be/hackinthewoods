using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Data
{
    public class Position
    {

        #region Fields
        private int x;
        private int y;
        #endregion

        #region Constructor
        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        #endregion

        #region Properties
        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        #endregion

    }
}
