using System.Collections.Generic;
using UnityEngine;

namespace Chess.Pieces
{
    public class Pawn : Piece
    {
        /*
         * TODO:
         *     promotion
         *     check en passant
         */
        private readonly int _direction;

        public Pawn(PlayerColor playerColor, Coord coord, Board board) : base(playerColor, coord, board)
        {
            _direction = (Color == PlayerColor.Black ? -1 : 1);
        }
        
        public override void GenerateAttackMap()
        {
            GenerateAttackMapCell(Position.X + 1, Position.Y + _direction);
            GenerateAttackMapCell(Position.X - 1, Position.Y + _direction);
        }

        public override void UpdateAllowedCells()
        {
            base.UpdateAllowedCells();
            
            AllowedCells.AddRange(NormalMovement());
            AllowedCells.AddRange(FirstMovement());
            AllowedCells.AddRange(Capture());
            AllowedCells.AddRange(CaptureEnPassant());
        }
        

        private List<Cell> NormalMovement()
        {
            List<Cell> allowedCells = new List<Cell>();
            int targetY = CurrentCell.Position.Y + _direction;
            int targetX = CurrentCell.Position.X;
            Cell targetCell = Board.GetCell(targetX, targetY);

            if (targetCell.IsEmpty)
            {
                allowedCells.Add(targetCell);
            }
            
            return allowedCells;
        }
        
        private List<Cell> FirstMovement()
        {
            List<Cell> allowedCells = new List<Cell>();
            
            int targetY = CurrentCell.Position.Y + 2 * _direction;
            int targetX = CurrentCell.Position.X;
            Cell targetCell = Board.GetCell(targetX, targetY);
            Cell previousCell = Board.GetCell(targetX, targetY - _direction);
            
            if (NumberMovements == 0 && NormalMovement().Count != 0 && targetCell.IsEmpty && previousCell.IsEmpty)
            {
                allowedCells.Add(targetCell);
            }
            
            return allowedCells;
        }
        
        private List<Cell> Capture()
        {
            List<Cell> allowedCells = new List<Cell>();
            int targetY = CurrentCell.Position.Y + _direction;
            int targetX = CurrentCell.Position.X + 1;
            Cell targetCell = Board.GetCell(targetX, targetY);

            if (targetCell == null)
                return allowedCells;;
                
            targetCell.SetUnderAttack(Color);
            
            if (!targetCell.IsEmpty && targetCell.CurrentPiece.Color != Color)
            {
                allowedCells.Add(targetCell);
            }
            
            targetX = CurrentCell.Position.X - 1;
            targetCell = Board.GetCell(targetX, targetY);

            if (targetCell == null)
                return allowedCells;
                
            targetCell.SetUnderAttack(Color);
            
            if (!targetCell.IsEmpty && targetCell.CurrentPiece.Color != Color)
            {
                allowedCells.Add(targetCell);

            }
            
            return allowedCells;
        }
        
        private List<Cell> CaptureEnPassant()
        {
            List<Cell> allowedCells = new List<Cell>();
            int targetY = CurrentCell.Position.Y;
            int targetX = CurrentCell.Position.X;

            //TODO: check it was the previous move not only the first one but i need to implement turns first
            
            Cell targetCell = Board.GetCell(targetX + 1, targetY + _direction);
            Cell passantCell = Board.GetCell(targetX + 1, targetY);
            if (targetCell != null && targetCell.IsEmpty && IsPawnEnPassant(passantCell))
            {
                allowedCells.Add(targetCell);
            }

            targetCell = Board.GetCell(targetX - 1, targetY + _direction);
            passantCell = Board.GetCell(targetX - 1, targetY);
            if (targetCell != null && targetCell.IsEmpty && IsPawnEnPassant(passantCell))
            {
                allowedCells.Add(targetCell);
            }
            
            return allowedCells;
        }
        
                
        private bool IsPawnEnPassant(Cell cell)
        {
            return
                !cell.IsEmpty && 
                cell.CurrentPiece.Color != Color &&
                cell.CurrentPiece is Pawn &&
                cell.CurrentPiece.NumberMovements == 1;
        }

        protected override void Kill(Cell cell)
        {
            Cell targetCell = Board.GetCell(cell.Position.X, cell.Position.Y - _direction);

            if (!cell.IsEmpty && cell.CurrentPiece.Color != Color)
            {
                cell.CurrentPiece.Destroy();
            } else if (IsPawnEnPassant(targetCell))
            {
                targetCell.CurrentPiece.Destroy();
            }
        }
    }
}
