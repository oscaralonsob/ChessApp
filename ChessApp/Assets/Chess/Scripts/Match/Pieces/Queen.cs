﻿using System.Collections.Generic;

namespace Chess.Match.Pieces
{
    public class Queen : Piece
    {
        public Queen(PlayerColor playerColor, Coord coord) : base(playerColor, coord)
        {
        }
        
        public override List<RayMove> RayMoves
            => new List<RayMove>
            {
                new RayMove(Position, new Coord(0,1), int.MaxValue),
                new RayMove(Position, new Coord(0,-1), int.MaxValue),
                new RayMove(Position, new Coord(1,0), int.MaxValue),
                new RayMove(Position, new Coord(-1,0), int.MaxValue),
                new RayMove(Position, new Coord(1,1), int.MaxValue),
                new RayMove(Position, new Coord(1,-1), int.MaxValue),
                new RayMove(Position, new Coord(-1,1), int.MaxValue),
                new RayMove(Position, new Coord(-1,-1), int.MaxValue),
            };
    }
}
