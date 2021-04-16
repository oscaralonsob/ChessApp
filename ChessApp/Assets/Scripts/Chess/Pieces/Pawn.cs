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

        public Pawn(PlayerColor playerColor, Cell currentCell) : base(playerColor, currentCell)
        {
            _direction = (Color == PlayerColor.Black ? -1 : 1);
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
            int targetY = CurrentCell.Y + _direction;
            int targetX = CurrentCell.X;
            Cell targetCell = CurrentCell.Board.GetCell(targetX, targetY);

            if (EmptyTargetCell(targetCell))
            {
                allowedCells.Add(targetCell);
            }
            
            return allowedCells;
        }
        
        private List<Cell> FirstMovement()
        {
            List<Cell> allowedCells = new List<Cell>();
            
            int targetY = CurrentCell.Y + 2 * _direction;
            int targetX = CurrentCell.X;
            Cell targetCell = CurrentCell.Board.GetCell(targetX, targetY);
            
            if (NumberMovements == 0 && NormalMovement().Count != 0 && EmptyTargetCell(targetCell))
            {
                allowedCells.Add(targetCell);
            }
            
            return allowedCells;
        }
        
        private List<Cell> Capture()
        {
            List<Cell> allowedCells = new List<Cell>();
            int targetY = CurrentCell.Y + _direction;
            int targetX = CurrentCell.X + 1;
            Cell targetCell = CurrentCell.Board.GetCell(targetX, targetY);

            if (EnemyTargetCell(targetCell))
            {
                allowedCells.Add(targetCell);
            }
            
            targetX = CurrentCell.X - 1;
            targetCell = CurrentCell.Board.GetCell(targetX, targetY);

            
            if (EnemyTargetCell(targetCell))
            {
                allowedCells.Add(targetCell);

            }
            
            return allowedCells;
        }
        
        private List<Cell> CaptureEnPassant()
        {
            List<Cell> allowedCells = new List<Cell>();
            int targetY = CurrentCell.Y;
            int targetX = CurrentCell.X;

            //TODO: check it was previous move not only the first one but i need to implement turns first
            
            Cell targetCell = CurrentCell.Board.GetCell(targetX + 1, targetY + _direction);
            Cell passantCell = CurrentCell.Board.GetCell(targetX + 1, targetY);
            if (EmptyTargetCell(targetCell) && IsPawnEnPassant(passantCell))
            {
                allowedCells.Add(targetCell);
            }

            targetCell = CurrentCell.Board.GetCell(targetX - 1, targetY + _direction);
            passantCell = CurrentCell.Board.GetCell(targetX - 1, targetY);
            if (EmptyTargetCell(targetCell) && IsPawnEnPassant(passantCell))
            {
                allowedCells.Add(targetCell);
            }
            
            return allowedCells;
        }
        
                
        private bool IsPawnEnPassant(Cell cell)
        {
            return
                EnemyTargetCell(cell) &&
                cell.CurrentPiece is Pawn &&
                cell.CurrentPiece.NumberMovements == 1;
        }

        protected override void Kill(Cell cell)
        {
            Cell targetCell = CurrentCell.Board.GetCell(cell.X, cell.Y - _direction);

            if (EnemyTargetCell(cell))
            {
                cell.CurrentPiece.Destroy();
            } else if (IsPawnEnPassant(targetCell))
            {
                targetCell.CurrentPiece.Destroy();
            }
        }
    }
}
