using System.Collections.Generic;

namespace Chess.Pieces
{
    public class Queen : Piece
    {
        public Queen(PlayerColor playerColor, Cell currentCell) : base(playerColor, currentCell)
        {
        }
        
        public override void UpdateAllowedCells()
        {
            base.UpdateAllowedCells();
            
            AllowedCells.AddRange(StraightPath(0, 1, CurrentCell.Board.Size));
            AllowedCells.AddRange(StraightPath(0, -1, CurrentCell.Board.Size));
            AllowedCells.AddRange(StraightPath(1, 0, CurrentCell.Board.Size));
            AllowedCells.AddRange(StraightPath(-1, 0, CurrentCell.Board.Size));
            
            AllowedCells.AddRange(StraightPath(1, 1, CurrentCell.Board.Size));
            AllowedCells.AddRange(StraightPath(1, -1, CurrentCell.Board.Size));
            AllowedCells.AddRange(StraightPath(-1, 1, CurrentCell.Board.Size));
            AllowedCells.AddRange(StraightPath(-1, -1, CurrentCell.Board.Size));
        }
    }
}
