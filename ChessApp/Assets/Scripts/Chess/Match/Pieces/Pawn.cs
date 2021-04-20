using System.Collections.Generic;
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
            };

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
