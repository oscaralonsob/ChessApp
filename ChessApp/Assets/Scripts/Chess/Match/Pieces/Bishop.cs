using System.Collections.Generic;

namespace Chess.Match.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(PlayerColor playerColor, Coord coord, Board board) : base(playerColor, coord, board)
        {
        }

        public override List<RayMove> RayMoves
            => new List<RayMove>
            {
                new RayMove(Position, new Coord(1,1), Board.Size, Board),
                new RayMove(Position, new Coord(1,-1), Board.Size, Board),
                new RayMove(Position, new Coord(-1,1), Board.Size, Board),
                new RayMove(Position, new Coord(-1,-1), Board.Size, Board),
            };
    }
}
