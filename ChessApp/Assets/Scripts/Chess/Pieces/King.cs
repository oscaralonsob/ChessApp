using System.Collections.Generic;

namespace Chess.Pieces
{
    public class King : Piece
    {
        //TODO: castle
        public King(PlayerColor playerColor, Cell currentCell) : base(playerColor, currentCell)
        {
        }

        public override List<Cell> Movement()
        {
            List<Cell> allowedCells = new List<Cell>();

            allowedCells.AddRange(StraightPath(0, 1, 1));
            allowedCells.AddRange(StraightPath(0, -1, 1));
            allowedCells.AddRange(StraightPath(1, 0, 1));
            allowedCells.AddRange(StraightPath(-1, 0, 1));
            
            allowedCells.AddRange(StraightPath(1, 1, 1));
            allowedCells.AddRange(StraightPath(1, -1, 1));
            allowedCells.AddRange(StraightPath(-1, 1, 1));
            allowedCells.AddRange(StraightPath(-1, -1, 1));
            
            return allowedCells;
        }
    }
}
