using System.Collections.Generic;

namespace Chess.Pieces
{
    public class Rook : Piece
    {
        public Rook(PlayerColor playerColor, Coord coord, Board board) : base(playerColor, coord, board)
        {
        }

        public override void UpdateAllowedCells()
        {
            base.UpdateAllowedCells();
            
            AllowedCells.AddRange(StraightPath(0, 1, Board.Size));
            AllowedCells.AddRange(StraightPath(0, -1, Board.Size));
            AllowedCells.AddRange(StraightPath(1, 0, Board.Size));
            AllowedCells.AddRange(StraightPath(-1, 0, Board.Size));
        }
    }
}
