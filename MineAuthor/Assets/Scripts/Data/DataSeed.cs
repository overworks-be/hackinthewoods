using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Data
{
    public class DataSeed
    {
        public static int[][] getMap(int width, int height, List<Position> positions)
        {
            int[][] map = new int[height][];
            for (int i = 0; i < height; i++)
            {
                map[i] = new int[width];
            }


            foreach (Position position in positions)
            {
                map[position.Y][position.X] = 1;
            }


            return map;
        }

    }
}
