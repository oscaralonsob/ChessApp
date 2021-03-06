using System.Collections.Generic;

namespace Chess.Match.Pieces
{
    public class King : Piece
    {

        public King(PlayerColor playerColor, Coord coord) : base(playerColor, coord)
        {
        }
        
        public override List<RayMove> RayMoves
            => new List<RayMove>
            {
                new RayMove(Position, new Coord(0,1), 1),
                new RayMove(Position, new Coord(0,-1), 1),
                new RayMove(Position, new Coord(1,0), 1),
                new RayMove(Position, new Coord(-1,0), 1),
                new RayMove(Position, new Coord(1,1), 1),
                new RayMove(Position, new Coord(1,-1), 1),
                new RayMove(Position, new Coord(-1,1), 1),
                new RayMove(Position, new Coord(-1,-1), 1),
                
                new RayMove(Position, new Coord(2,0), 1) {IsShortCastle = true},
                new RayMove(Position, new Coord(-2, 0), 1) {IsLongCastle = true}
            };
    }
}
