using System.Collections.Generic;

namespace Chess.Pieces
{
    public class Rook : Piece
    {
        public Rook(PlayerColor playerColor, Cell currentCell) : base(playerColor, currentCell)
        {
        }

        public override List<Cell> Movement()
        {
            if (!IsMyTurn())
            {
                return new List<Cell>();
            }
            
            List<Cell> allowedCells = new List<Cell>();

            allowedCells.AddRange(StraightPath(0, 1, CurrentCell.Board.Size));
            allowedCells.AddRange(StraightPath(0, -1, CurrentCell.Board.Size));
            allowedCells.AddRange(StraightPath(1, 0, CurrentCell.Board.Size));
            allowedCells.AddRange(StraightPath(-1, 0, CurrentCell.Board.Size));
            
            return allowedCells;
        }
    }
}
