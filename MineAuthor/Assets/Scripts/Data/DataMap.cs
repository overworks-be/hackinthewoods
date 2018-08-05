﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    class DataMap
    {
        public static int[][] map =
     {       //0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 
    new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, //0
    new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, //1
    new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, //2
    new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, //3
    new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, //4
    new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, //5
    new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, //6
    new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, //7
    new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, //8
    new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, //9
    new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, //10
    new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, //11
    new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, //12
    new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, //13
    new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, //14
    new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, //15
    new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, //16
    new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, //17
    new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, //18
    new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, //19
    new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, //20
    new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, //21
    new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, //22
    new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, //23
    new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, //24
    new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, //25
    new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, //26
    new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, //27
    new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, //28
    new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, //29
    new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, //30
    new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, //31
    new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, //32
    new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, //33
    new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, //34
    new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, //35
    new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, //36
    new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, //37
    new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, //38
    new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, //39
    new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, //40
    new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, //41
    new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, //42
    new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, //43
    new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, //44
                                                         
                                                         
};
    }
}
