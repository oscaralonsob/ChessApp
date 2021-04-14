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

        public override List<Cell> Movement()
        {
            if (!IsMyTurn())
            {
                return new List<Cell>();
            }
            
            List<Cell> allowedCells = new List<Cell>();

            allowedCells.AddRange(NormalMovement());
            allowedCells.AddRange(FirstMovement());
            allowedCells.AddRange(Capture());
            allowedCells.AddRange(CaptureEnPassant());
            
            return allowedCells;
        }

        private List<Cell> NormalMovement()
        {
            List<Cell> allowedCells = new List<Cell>();
            int targetY = CurrentCell.Y + _direction;
            int targetX = CurrentCell.X;
            
            if (EmptyTargetCell(targetX, targetY))
            {
                allowedCells.Add(CurrentCell.Board.Cells[targetX, targetY]);
            }
            
            return allowedCells;
        }
        
        private List<Cell> FirstMovement()
        {
            List<Cell> allowedCells = new List<Cell>();
            
            int targetY = CurrentCell.Y + 2 * _direction;
            int targetX = CurrentCell.X;
            
            if (NumberMovements == 0 && NormalMovement().Count != 0 && EmptyTargetCell(targetX, targetY))
            {
                allowedCells.Add(CurrentCell.Board.Cells[targetX, targetY]);
            }
            
            return allowedCells;
        }
        
        private List<Cell> Capture()
        {
            List<Cell> allowedCells = new List<Cell>();
            int targetY = CurrentCell.Y + _direction;
            int targetX = CurrentCell.X + 1;

            if (EnemyTargetCell(targetX, targetY))
            {
                allowedCells.Add(CurrentCell.Board.Cells[targetX, targetY]);
            }
            
            targetX = CurrentCell.X - 1;
            
            if (EnemyTargetCell(targetX, targetY))
            {
                allowedCells.Add(CurrentCell.Board.Cells[targetX, targetY]);
            }
            
            return allowedCells;
        }
        
        private List<Cell> CaptureEnPassant()
        {
            List<Cell> allowedCells = new List<Cell>();
            int targetY = CurrentCell.Y;
            int targetX = CurrentCell.X;

            //TODO: check it was previous movement not only the first one but i need to implement turns first
            if (EmptyTargetCell(targetX + 1, targetY + _direction) && IsPawnEnPassant(targetX + 1, targetY))
            {
                allowedCells.Add(CurrentCell.Board.Cells[targetX + 1, targetY + _direction]);
            }

            if (EmptyTargetCell(targetX - 1, targetY + _direction) && IsPawnEnPassant(targetX - 1, targetY))
            {
                allowedCells.Add(CurrentCell.Board.Cells[targetX - 1, targetY + _direction]);
            }
            
            return allowedCells;
        }
        
                
        private bool IsPawnEnPassant(int x, int y)
        {
            return
                EnemyTargetCell(x, y) &&
                CurrentCell.Board.Cells[x, y].CurrentPiece is Pawn &&
                CurrentCell.Board.Cells[x, y].CurrentPiece.NumberMovements == 1;
        }
    }
}
