using System.Collections.Generic;
using UnityEngine.Rendering;

namespace Chess.Pieces
{
    public class Knight : Piece
    {
        public Knight(PlayerColor playerColor, Cell currentCell) : base(playerColor, currentCell)
        {
        }

        public override List<Cell> Movement()
        {
            List<Cell> allowedCells = new List<Cell>();
            
            allowedCells.AddRange(CreatePath(2, 1));
            allowedCells.AddRange(CreatePath(1, 2));
            allowedCells.AddRange(CreatePath(-2, 1));
            allowedCells.AddRange(CreatePath(-1, 2));
            
            allowedCells.AddRange(CreatePath(2, -1));
            allowedCells.AddRange(CreatePath(1, -2));
            allowedCells.AddRange(CreatePath(-2, -1));
            allowedCells.AddRange(CreatePath(-1, -2));
            
            return allowedCells;
        }
        
        private List<Cell> CreatePath(int x, int y)
        {
            List<Cell> allowedCells = new List<Cell>();
            int targetY = CurrentCell.Y + y;
            int targetX = CurrentCell.X + x;

            if (CheckCell(targetX, targetY))
            {
                allowedCells.Add(CurrentCell.Board.Cells[targetX, targetY]);
            }

            return allowedCells;
        }
    }
}
