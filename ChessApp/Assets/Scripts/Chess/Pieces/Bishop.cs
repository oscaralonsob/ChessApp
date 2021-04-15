using System.Collections.Generic;

namespace Chess.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(PlayerColor playerColor, Cell currentCell) : base(playerColor, currentCell)
        {
        }
        
        
        public override void UpdateAllowedCells()
        {
            base.UpdateAllowedCells();
            
            AllowedCells.AddRange(StraightPath(1, 1, CurrentCell.Board.Size));
            AllowedCells.AddRange(StraightPath(1, -1, CurrentCell.Board.Size));
            AllowedCells.AddRange(StraightPath(-1, 1, CurrentCell.Board.Size));
            AllowedCells.AddRange(StraightPath(-1, -1, CurrentCell.Board.Size));
        }
    }
}
