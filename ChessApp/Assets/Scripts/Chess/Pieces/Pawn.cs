using System.Collections.Generic;
using UnityEngine;

namespace Chess.Pieces
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
        
        public override void GenerateAttackMap()
        {
            GenerateAttackMapCell(Position.X + 1, Position.Y + _direction);
            GenerateAttackMapCell(Position.X - 1, Position.Y + _direction);
        }

        public override void UpdateMoves()
        {
            base.UpdateMoves();
            
            StraightPath(0,_direction,NumberMovements == 0 ? 2 : 1);
            StraightPath(1,_direction,1);
            StraightPath(-1,_direction,1);
        }
    }
}
