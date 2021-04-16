using System.Collections.Generic;
using Controller;
using UnityEngine;

namespace Chess.Pieces
{
    public abstract class Piece
    {
        public PlayerColor Color { get; }
        public Cell CurrentCell { get; private set;  }
        
        public PieceController PieceController { get; set; }
        
        public int NumberMovements { get; private set; }
        
        public List<Cell> AllowedCells { get; protected set; }
        
        private bool IsUnderAttack { get; set; }

        protected Piece(PlayerColor playerColor, Cell currentCell)
        {
            Color = playerColor;
            SwitchCell(currentCell);
            NumberMovements = 0;
            AllowedCells = new List<Cell>();
            IsUnderAttack = false;
        }
        
        public string GetSpriteName()
        {
            return "Chess" + GetType().Name + Color;
        }
        
        public bool Move(Cell cell)
        {
            if (!IsMyTurn())
            {
                return false;
            }
            
            if (AllowedCells.Contains(cell))
            {
                Kill(cell);
                SwitchCell(cell);
                NumberMovements++;
                CurrentCell.Board.SwitchTurn();
                return true;
            }

            return false;
        }

        public bool IsMyTurn()
        {
            return CurrentCell.Board.ColorTurn == Color;
        }

        protected List<Cell> StraightPath(int xDirection, int yDirection, int distance)
        {
            List<Cell> allowedCells = new List<Cell>();
            int targetY = CurrentCell.Y;
            int targetX = CurrentCell.X;
            
            for (int x = 1; x <= distance; x++)
            {
                targetX += xDirection;
                targetY += yDirection;
                Cell targetCell = CurrentCell.Board.GetCell(targetX, targetY);
                if (CheckCell(targetCell))
                {
                    allowedCells.Add(targetCell);
                }

                if (!EmptyTargetCell(targetCell))
                {
                    if (EnemyTargetCell(targetCell) && 
                        targetCell.CurrentPiece.Color != Color)
                    {
                        targetCell.CurrentPiece.IsUnderAttack = true;
                    }
                    break;
                }
            }

            return allowedCells;
        }
        
        protected bool CheckCell(Cell cell)
        {
            return EmptyTargetCell(cell) || EnemyTargetCell(cell);
        }

        protected bool EmptyTargetCell(Cell cell)
        {
            return cell?.CurrentPiece == null;
        }
        
        protected bool EnemyTargetCell(Cell cell)
        {
            return cell?.CurrentPiece.Color != Color;
        }
        
        private void SwitchCell(Cell cell)
        {
            if (CurrentCell != null)
            {
                CurrentCell.CurrentPiece = null;
            }
            CurrentCell = cell;
            CurrentCell.CurrentPiece = this;
        }
        
        protected virtual void Kill(Cell cell)
        {
            if (EnemyTargetCell(cell))
            {
                cell.CurrentPiece.Destroy();
            }
        }

        public void Destroy()
        {
            CurrentCell.CurrentPiece = null;
            CurrentCell = null;
            PieceController.Destroy();
        }

        public virtual void UpdateAllowedCells()
        {
            AllowedCells.Clear();
        }
    }
}
