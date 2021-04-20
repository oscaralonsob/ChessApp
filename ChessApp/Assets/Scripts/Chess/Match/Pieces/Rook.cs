using System.Collections.Generic;

namespace Chess.Match.Pieces
{
    public class Rook : SlidingPiece
    {
        public Rook(PlayerColor playerColor, Coord coord, Board board) : base(playerColor, coord, board)
        {
        }
        
        public override List<RayMove> RayMoves
            => new List<RayMove>
            {
                new RayMove(Position, new Coord(0,1), Board.Size),
                new RayMove(Position, new Coord(0,-1), Board.Size),
                new RayMove(Position, new Coord(1,0), Board.Size),
                new RayMove(Position, new Coord(-1,0), Board.Size),
            };

        public override void UpdateMoves()
        {
            base.UpdateMoves();
            
            StraightPath(0, 1, Board.Size);
            StraightPath(0, -1, Board.Size);
            StraightPath(1, 0, Board.Size);
            StraightPath(-1, 0, Board.Size);
        }
    }
}
