using System.Collections.Generic;

namespace Chess.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(PlayerColor playerColor, Cell currentCell) : base(playerColor, currentCell)
        {
        }

        public override List<Cell> Movement()
        {
            List<Cell> allowedCells = new List<Cell>();

            allowedCells.AddRange(StraightPath(1, 1, CurrentCell.Board.Size));
            allowedCells.AddRange(StraightPath(1, -1, CurrentCell.Board.Size));
            allowedCells.AddRange(StraightPath(-1, 1, CurrentCell.Board.Size));
            allowedCells.AddRange(StraightPath(-1, -1, CurrentCell.Board.Size));
            
            return allowedCells;
        }
    }
}
