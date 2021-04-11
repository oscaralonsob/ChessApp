using System;
using System.Collections.Generic;
using Chess.Pieces;

namespace Chess.GameMode
{
    public class NormalGameMode : IGameMode
    {
        public Dictionary<Tuple<int, int>, Type> PiecePlacement()
        {
            return new Dictionary<Tuple<int, int>, Type>
            {
                {new Tuple<int, int>(0,0), typeof(Rook)},
                {new Tuple<int, int>(1,0), typeof(Knight)},
                {new Tuple<int, int>(2,0), typeof(Bishop)},
                {new Tuple<int, int>(3,0), typeof(Queen)},
                {new Tuple<int, int>(4,0), typeof(King)},
                {new Tuple<int, int>(5,0), typeof(Bishop)},
                {new Tuple<int, int>(6,0), typeof(Knight)},
                {new Tuple<int, int>(7,0), typeof(Rook)},
                {new Tuple<int, int>(0,1), typeof(Pawn)},
                {new Tuple<int, int>(1,1), typeof(Pawn)},
                {new Tuple<int, int>(2,1), typeof(Pawn)},
                {new Tuple<int, int>(3,1), typeof(Pawn)},
                {new Tuple<int, int>(4,1), typeof(Pawn)},
                {new Tuple<int, int>(5,1), typeof(Pawn)},
                {new Tuple<int, int>(6,1), typeof(Pawn)},
                {new Tuple<int, int>(7,1), typeof(Pawn)},
            };
        }
        
    }
}