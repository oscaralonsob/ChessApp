using System.Collections.Generic;

namespace Chess.Match.Pieces
{
    public class King : Piece
    {
        //TODO: castle
        public King(PlayerColor playerColor, Coord coord, Board board) : base(playerColor, coord, board)
        {
        }
        
        public override List<RayMove> RayMoves
            => new List<RayMove>
            {
                new RayMove(Position, new Coord(0,1), 1, Board),
                new RayMove(Position, new Coord(0,-1), 1, Board),
                new RayMove(Position, new Coord(1,0), 1, Board),
                new RayMove(Position, new Coord(-1,0), 1, Board),
                new RayMove(Position, new Coord(1,1), 1, Board),
                new RayMove(Position, new Coord(1,-1), 1, Board),
                new RayMove(Position, new Coord(-1,1), 1, Board),
                new RayMove(Position, new Coord(-1,-1), 1, Board),
            };
    }
}
