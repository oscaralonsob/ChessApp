using System.Collections.Generic;

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
        
        public override List<RayMove> RayMoves
            => new List<RayMove>
            {
                new RayMove(Position, new Coord(1,_direction), 1, Board),
                new RayMove(Position, new Coord(-1,_direction), 1, Board),
                //TODO: implement something like is capture or something like that
                new RayMove(Position, new Coord(0,_direction), NumberMovements == 0 ? 2 : 1, Board),

            };
    }
}
