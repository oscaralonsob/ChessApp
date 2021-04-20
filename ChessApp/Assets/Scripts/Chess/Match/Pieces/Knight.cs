﻿using System.Collections.Generic;
using UnityEngine.Rendering;

namespace Chess.Match.Pieces
{
    public class Knight : Piece
    {
        public Knight(PlayerColor playerColor, Coord coord, Board board) : base(playerColor, coord, board)
        {
        }
        
        public override List<RayMove> RayMoves
            => new List<RayMove>
            {
                new RayMove(Position, new Coord(2,1), 1),
                new RayMove(Position, new Coord(1,2), 1),
                
                new RayMove(Position, new Coord(-2,1), 1),
                new RayMove(Position, new Coord(-1,2), 1),
                
                new RayMove(Position, new Coord(2,-1), 1),
                new RayMove(Position, new Coord(1,-2), 1),
                
                new RayMove(Position, new Coord(-2,-1), 1),
                new RayMove(Position, new Coord(-1,-2), 1),
            };

        public override void UpdateMoves()
        {
            base.UpdateMoves();
            
            CreatePath(2, 1);
            CreatePath(1, 2);
            CreatePath(-2, 1);
            CreatePath(-1, 2);
            
            CreatePath(2, -1);
            CreatePath(1, -2);
            CreatePath(-2, -1);
            CreatePath(-1, -2);
        }
    }
}
