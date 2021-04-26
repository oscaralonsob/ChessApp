using System;
using Chess.Match.Pieces;
using UnityEngine;

namespace Chess.Match
{
    public class RayMove
    {
        public Coord Origin { get; }
        
        public Coord Vector { get; }
        
        public int Range { get; }

        public RayMove(Coord origin, Coord vector, int range)
        {
            Origin = origin;
            Vector = vector;
            Range = range;
        }

        public bool PointIsInSegment(Coord toCheck)
        {
            Coord end = Origin + Range * Vector;
            bool collinear = (end.X - Origin.X) * (toCheck.Y - Origin.Y) == (toCheck.X - Origin.X) * (end.Y - Origin.Y);

            if (!collinear)
                return false;

            if (Origin.Y == end.Y)
                return Origin.X <= toCheck.X && toCheck.X <= end.X || Origin.X >= toCheck.X && toCheck.X >= end.X;
            
            return Origin.Y <= toCheck.Y && toCheck.Y <= end.Y || Origin.Y >= toCheck.Y && toCheck.Y >= end.Y;
        }
    }   
}
