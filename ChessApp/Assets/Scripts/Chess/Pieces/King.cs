using System.Collections.Generic;

namespace Chess.Pieces
{
    public class King : Piece
    {
        //TODO: castle
        public King(PlayerColor playerColor, Cell currentCell) : base(playerColor, currentCell)
        {
        }
        
        public override void UpdateAllowedCells()
        {
            base.UpdateAllowedCells();
            
            AllowedCells.AddRange(StraightPath(0, 1, 1));
            AllowedCells.AddRange(StraightPath(0, -1, 1));
            AllowedCells.AddRange(StraightPath(1, 0, 1));
            AllowedCells.AddRange(StraightPath(-1, 0, 1));
            
            AllowedCells.AddRange(StraightPath(1, 1, 1));
            AllowedCells.AddRange(StraightPath(1, -1, 1));
            AllowedCells.AddRange(StraightPath(-1, 1, 1));
            AllowedCells.AddRange(StraightPath(-1, -1, 1));
        }
    }
}
