using System.Collections.Generic;
using Controller;
using UnityEngine;

namespace Chess.Pieces
{
    public abstract class Piece
    {
        public PieceController PieceController { get; set; }
        
        public PlayerColor Color { get; }
        
        public Coord Position { get; private set; }
        
        protected Board Board { get; }
        
        public Cell CurrentCell => Board.Cells[Position.X, Position.Y];
        
        public int NumberMovements { get; private set; }
        
        public List<Cell> AllowedCells { get; }

        public bool IsUnderAttack { get; set; }
        
        public bool IsPined { get; set; }

        protected Piece(PlayerColor playerColor, Coord coord, Board board)
        {
            Color = playerColor;
            Board = board;
            MoveToPosition(coord);
            NumberMovements = 0;
            AllowedCells = new List<Cell>();
            IsUnderAttack = false;
            IsPined = false;
        }
        
        public string GetSpriteName()
        {
            return "Chess" + GetType().Name + Color;
        }
        
        public void Move(Cell cell)
        {
            if (!IsMyTurn())
            {
                return;
            }
            
            if (AllowedCells.Contains(cell))
            {
                Kill(cell);
                RemoveFromCurrentCell();
                MoveToPosition(cell.Position);
                NumberMovements++;
                Board.SwitchTurn();
            }
        }

        public bool IsMyTurn()
        {
            return Board.ColorTurn == Color;
        }

        protected List<Cell> StraightPath(int xDirection, int yDirection, int distance)
        {
            List<Cell> allowedCells = new List<Cell>();
            int targetX = CurrentCell.Position.X;
            int targetY = CurrentCell.Position.Y;
            
            for (int x = 1; x <= distance; x++)
            {
                targetX += xDirection;
                targetY += yDirection;
                Cell targetCell = Board.GetCell(targetX, targetY);

                if (targetCell == null)
                    return allowedCells;
                
                targetCell.Meta.SetCellUnderAttack(Color);
                
                if (EmptyTargetCell(targetCell))
                {
                    allowedCells.Add(targetCell);
                } else if (EnemyTargetCell(targetCell))
                {
                    allowedCells.Add(targetCell);
                    //No more allowed movements, we can stop looking
                    break;
                } else if (FriendlyTargetCell(targetCell))
                {
                    //No more allowed movements, we can stop looking
                    break;
                }
            }

            return allowedCells;
        }
        
        protected bool CanMoveTo(Cell cell)
        {
            return EmptyTargetCell(cell) || EnemyTargetCell(cell);
        }

        protected bool EmptyTargetCell(Cell cell)
        {
            return 
                cell != null &&
                cell.IsEmpty;
        }
        
        protected bool FriendlyTargetCell(Cell cell)
        {
            return cell != null &&
                   !cell.IsEmpty && 
                   cell.CurrentPiece.Color == Color;
        }
        
        protected bool EnemyTargetCell(Cell cell)
        {
            return cell != null &&
                   !cell.IsEmpty && 
                   cell.CurrentPiece.Color != Color;
        }
        
        private void MoveToPosition(Coord coord)
        {
            Position = coord;
            CurrentCell.CurrentPiece = this;
        }
        
        private void RemoveFromCurrentCell()
        {
            CurrentCell.CurrentPiece = null;
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
            Board.Pieces.Remove(this);
            CurrentCell.CurrentPiece = null;
            PieceController.Destroy();
        }

        public virtual void UpdateAllowedCells()
        {
            AllowedCells.Clear();
            IsUnderAttack = false;
        }
    }
}
