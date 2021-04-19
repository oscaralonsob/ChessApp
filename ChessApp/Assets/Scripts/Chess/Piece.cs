using System.Collections.Generic;
using Chess.Pieces;
using Controller;
using UnityEngine;

namespace Chess
{
    public abstract class Piece
    {
        public PieceController PieceController { get; set; }
        
        public PlayerColor Color { get; }
        
        public Coord Position { get; set; }
        
        protected Board Board { get; }
        
        public Cell CurrentCell => Board.Cells[Position.X, Position.Y];
        
        public int NumberMovements { get; private set; }
        
        public List<Move> Moves { get; }

        public bool IsUnderAttack => Color == PlayerColor.White ? CurrentCell.IsUnderBlackAttack : CurrentCell.IsUnderWhiteAttack;

        public bool IsMyTurn => Board.ColorTurn == Color;

        protected Piece(PlayerColor playerColor, Coord coord, Board board)
        {
            Color = playerColor;
            Board = board;
            Position = coord;
            CurrentCell.CurrentPiece = this;
            NumberMovements = 0;
            Moves = new List<Move>();
        }
        
        public string GetSpriteName()
        {
            return "Chess" + GetType().Name + Color;
        }
        
        public void Move(Move move)
        {
            if (move.IsValid)
            {
                move.Apply(Board);
                NumberMovements++;
                Board.SwitchTurn();
            }
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

        protected void StraightPath(int xDirection, int yDirection, int distance)
        {
            int targetX = CurrentCell.Position.X;
            int targetY = CurrentCell.Position.Y;
            
            for (int x = 1; x <= distance; x++)
            {
                targetX += xDirection;
                targetY += yDirection;
                Move move = new Move(this, Board.GetCell(targetX, targetY));
                
                if (move.IsLegal(Board))
                {
                    Moves.Add(move);
                }

                if (move.IsLastInPath)
                {
                    break;
                }
            }
        }

        public void Destroy()
        {
            Board.Pieces.Remove(this);
            CurrentCell.CurrentPiece = null;
            PieceController.Destroy();
        }

        public virtual void UpdateMoves()
        {
            Moves.Clear();
        }
    }
}
