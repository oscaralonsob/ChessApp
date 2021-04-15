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

        protected Piece(PlayerColor playerColor, Cell currentCell)
        {
            Color = playerColor;
            SwitchCell(currentCell);
            NumberMovements = 0;
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
            
            if (Movement().Contains(cell))
            {
                Kill(cell);
                SwitchCell(cell);
                NumberMovements++;
                CurrentCell.Board.ColorTurn = CurrentCell.Board.ColorTurn == PlayerColor.Black
                    ? PlayerColor.White
                    : PlayerColor.Black;
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
                if (CheckCell(targetX, targetY))
                {
                    allowedCells.Add(CurrentCell.Board.Cells[targetX, targetY]);
                }

                if (!EmptyTargetCell(targetX, targetY))
                {
                    break;
                }
            }

            return allowedCells;
        }
        
        protected bool CheckCell(int x, int y)
        {
            return EmptyTargetCell(x, y) || EnemyTargetCell(x, y);
        } 
        
        private bool ValidTargetCell(int x, int y)
        {
            return 
                x >= 0 && 
                y >=0 && 
                x < CurrentCell.Board.Size && 
                y < CurrentCell.Board.Size;
        }

        protected bool EmptyTargetCell(int x, int y)
        {
            return 
                ValidTargetCell(x, y) &&
                CurrentCell.Board.Cells[x, y].CurrentPiece == null;
        }
        
        protected bool EnemyTargetCell(int x, int y)
        {
            return 
                ValidTargetCell(x, y) &&
                !EmptyTargetCell(x, y) &&
                CurrentCell.Board.Cells[x, y].CurrentPiece.Color != Color;
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
            if (EnemyTargetCell(cell.X, cell.Y))
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

        public abstract List<Cell> Movement();
    }
}
