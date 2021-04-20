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
    }   
}
