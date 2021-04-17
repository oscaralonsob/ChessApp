﻿using System;
using Chess.Pieces;
using Controller;

namespace Chess
{
    public class Coord
    {
        public int X { get; }
        public int Y { get; }

        public Coord(int x, int y)
        {
            X = x;
            Y = y;
        }
    }   
}
