using System.Collections.Generic;

namespace Chess.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(PlayerColor playerColor, Cell currentCell) : base(playerColor, currentCell)
        {
        }

        public override List<Cell> Movement()
        {
            List<Cell> allowedCells = new List<Cell>();

            int targetY = CurrentCell.Y;
            int targetX = CurrentCell.X;

            // "Normal" movement
            targetY += (Color == PlayerColor.Black ? -1 : 1); 
            allowedCells.Add(CurrentCell.Board.Cells[targetX, targetY]);
            
            /*
             * TODO:
             *     First Movement
             *     Capture
             *     Capture en passant
             *     Promotion
             *     Check if any of this are blocked
             */
            
            return allowedCells;
        }
    }
}
