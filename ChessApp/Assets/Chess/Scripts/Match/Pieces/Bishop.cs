using System.Collections.Generic;

namespace Chess.Match.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(PlayerColor playerColor, Coord coord) : base(playerColor, coord)
        {
        }

        public override List<RayMove> RayMoves
            => new List<RayMove>
            {
                new RayMove(Position, new Coord(1,1), int.MaxValue),
                new RayMove(Position, new Coord(1,-1), int.MaxValue),
                new RayMove(Position, new Coord(-1,1), int.MaxValue),
                new RayMove(Position, new Coord(-1,-1), int.MaxValue),
            };
    }
}
