using System.Collections.Generic;

namespace Chess.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(PlayerColor playerColor, Coord coord, Board board) : base(playerColor, coord, board)
        {
        }
        
        
        public override void UpdateAllowedCells()
        {
            base.UpdateAllowedCells();
            
            AllowedCells.AddRange(StraightPath(1, 1, Board.Size));
            AllowedCells.AddRange(StraightPath(1, -1, Board.Size));
            AllowedCells.AddRange(StraightPath(-1, 1, Board.Size));
            AllowedCells.AddRange(StraightPath(-1, -1, Board.Size));
        }
    }
}
