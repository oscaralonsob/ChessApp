using System.Collections.Generic;

namespace Chess.Match.Pieces
{
    public class Pawn : Piece
    {
        /*
         * TODO:
         *     promotion
         */
        public int Direction { get; }

        public Pawn(PlayerColor playerColor, Coord coord, Board board) : base(playerColor, coord, board)
        {
            Direction = (Color == PlayerColor.Black ? -1 : 1);
        }
        
        public override List<RayMove> RayMoves
            => new List<RayMove>
            {
                new RayMove(Position, new Coord(1,Direction), 1),
                new RayMove(Position, new Coord(-1,Direction), 1),
                //TODO: implement something like is capture or something like that
                new RayMove(Position, new Coord(0,Direction), NumberMovements == 0 ? 2 : 1),

            };
    }
}
