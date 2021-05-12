﻿using System.Collections.Generic;

namespace Chess.Match.Pieces
{
    public class Rook : Piece
    {
        public Rook(PlayerColor playerColor, Coord coord) : base(playerColor, coord)
        {
        }
        
        public override List<RayMove> RayMoves
            => new List<RayMove>
            {
                new RayMove(Position, new Coord(0,1), 8),
                new RayMove(Position, new Coord(0,-1), 8),
                new RayMove(Position, new Coord(1,0), 8),
                new RayMove(Position, new Coord(-1,0), 8),
            };
    }
}
