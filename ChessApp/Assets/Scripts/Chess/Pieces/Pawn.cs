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
            
            CreatePath(0,_direction);
            //TODO: maybe move this to the move class?
            if (NumberMovements == 0)
            {
                CreatePath(0,2 * _direction);
            }
            CreatePath(1,_direction);
            CreatePath(-1,_direction);
        }
    }
}
