﻿using System.Collections.Generic;
using UnityEngine;

namespace Chess.Match.Pieces
{
    public class Pawn : Piece
    {
        /*
         * TODO:
         *     promotion
         */
        private readonly int _direction;

        public Pawn(PlayerColor playerColor, Coord coord, Board board) : base(playerColor, coord, board)
        {
            _direction = (Color == PlayerColor.Black ? -1 : 1);
        }
        
        //TODO: Only Capture moves for now, need to add the others
        public override List<RayMove> RayMoves
            => new List<RayMove>
            {
                new RayMove(Position, new Coord(1,_direction), 1),
                new RayMove(Position, new Coord(-1,_direction), 1),
                //TODO: implement something like is capture or something like that
                new RayMove(Position, new Coord(0,_direction), NumberMovements == 0 ? 2 : 1),

            };
    }
}
