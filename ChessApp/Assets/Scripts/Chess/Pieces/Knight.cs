using System.Collections.Generic;
using UnityEngine.Rendering;

namespace Chess.Pieces
{
    public class Knight : Piece
    {
        public Knight(PlayerColor playerColor, Coord coord, Board board) : base(playerColor, coord, board)
        {
        }

        public override void GenerateAttackMap()
        {
            GenerateAttackMapCell(Position.X + 2, Position.Y + 1);
            GenerateAttackMapCell(Position.X + 1, Position.Y + 2);
            GenerateAttackMapCell(Position.X - 2, Position.Y + 1);
            GenerateAttackMapCell(Position.X - 1, Position.Y + 2);
            
            GenerateAttackMapCell(Position.X + 2, Position.Y - 1);
            GenerateAttackMapCell(Position.X + 1, Position.Y - 2);
            GenerateAttackMapCell(Position.X - 2, Position.Y - 1);
            GenerateAttackMapCell(Position.X - 1, Position.Y - 2);
        }

        public override void UpdateAllowedCells()
        {
            base.UpdateAllowedCells();
            
            AllowedCells.AddRange(CreatePath(2, 1));
            AllowedCells.AddRange(CreatePath(1, 2));
            AllowedCells.AddRange(CreatePath(-2, 1));
            AllowedCells.AddRange(CreatePath(-1, 2));
            
            AllowedCells.AddRange(CreatePath(2, -1));
            AllowedCells.AddRange(CreatePath(1, -2));
            AllowedCells.AddRange(CreatePath(-2, -1));
            AllowedCells.AddRange(CreatePath(-1, -2));
        }

        private List<Cell> CreatePath(int x, int y)
        {
            List<Cell> allowedCells = new List<Cell>();
            int targetY = CurrentCell.Position.Y + y;
            int targetX = CurrentCell.Position.X + x;

            Cell targetCell = Board.GetCell(targetX, targetY);
            
            if (targetCell == null)
                return allowedCells;;
                
            targetCell.SetUnderAttack(Color);

            if (targetCell.IsEmpty || 
                 targetCell.CurrentPiece.Color != Color)
            {
                allowedCells.Add(targetCell);
            }

            return allowedCells;
        }
    }
}
