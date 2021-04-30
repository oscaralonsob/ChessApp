using System.Collections.Generic;

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
    }
}
