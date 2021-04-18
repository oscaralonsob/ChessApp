using System.Collections.Generic;
using Controller;
using UnityEngine;

namespace Chess
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

        public bool IsUnderAttack => Color == PlayerColor.White ? CurrentCell.IsUnderBlackAttack : CurrentCell.IsUnderWhiteAttack;

        protected Piece(PlayerColor playerColor, Coord coord, Board board)
        {
            Color = playerColor;
            Board = board;
            MoveToPosition(coord);
            NumberMovements = 0;
            AllowedCells = new List<Cell>();
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
        
        public abstract void GenerateAttackMap();

        protected void GenerateAttackMapRow(int xDirection, int yDirection, int distance)
        {
            int targetX = CurrentCell.Position.X;
            int targetY = CurrentCell.Position.Y;
            for (int x = 1; x <= distance; x++)
            {
                targetX += xDirection;
                targetY += yDirection;
                GenerateAttackMapCell(targetX, targetY);

                Cell targetCell = Board.GetCell(targetX, targetY);
                if (targetCell == null || !targetCell.IsEmpty)
                {
                    break;
                }
            }
        }

        protected void GenerateAttackMapCell(int x, int y)
        {
            Cell targetCell = Board.GetCell(x, y);

            targetCell?.SetUnderAttack(Color);
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
                
                targetCell.SetUnderAttack(Color);
                
                if (targetCell.IsEmpty)
                {
                    allowedCells.Add(targetCell);
                } else if (targetCell.CurrentPiece.Color != Color)
                {
                    allowedCells.Add(targetCell);
                    //No more allowed movements, we can stop looking
                    break;
                } else
                {
                    //Ally piece, no more allowed movements, we can stop looking
                    break;
                }
            }

            return allowedCells;
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
            if (!cell.IsEmpty && cell.CurrentPiece.Color != Color)
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
        }
    }
}
