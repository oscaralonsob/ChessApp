using System;
using System.Collections.Generic;
using Chess.Pieces;
using Controller;
using UnityEngine;

namespace Chess
{
    //TODO: probably this class will determinate the game mode :D
    public class Move
    {
        public Piece Piece { get; }
        
        public Cell TargetCell { get; }

        public bool IsValid => TargetCell != null;
        
        public bool IsLastInPath => !IsValid || !TargetCell.IsEmpty;
        
        private bool IsCapture => IsValid && !TargetCell.IsEmpty && TargetCell.CurrentPiece.Color != Piece.Color;

        private bool IsCapturePassant { get; set; }

        public Move(Piece piece, Cell targetCell)
        {
            Piece = piece;
            TargetCell = targetCell;
        }
        
        public bool IsLegal(Board board)
        {
            if (!IsValid)
                return false;
            
            if (TargetCell.IsEmpty || TargetCell.CurrentPiece.Color != Piece.Color)
            {
                if (Piece is King)
                {                
                    bool targetCellUnderAttack = Piece.Color == PlayerColor.White ? TargetCell.IsUnderBlackAttack : TargetCell.IsUnderWhiteAttack;
                    return !targetCellUnderAttack;
                } 
                
                if (Piece is Pawn)
                {
                    //TODO: This direction is duplicated...
                    int direction = (Piece.Color == PlayerColor.Black ? -1 : 1);
                    Cell auxCell = board.GetCell(TargetCell.Position.X, TargetCell.Position.Y - direction);
                    IsCapturePassant = IsPassantLegal(auxCell);
                    return TargetCell.Position.X == Piece.Position.X && TargetCell.IsEmpty ||
                           TargetCell.Position.X != Piece.Position.X && !TargetCell.IsEmpty || 
                           IsCapturePassant;
                }

                return true;
            }

            return false;
        }

        public void Apply(Board board)
        {
            if (!IsLegal(board) || !Piece.IsMyTurn)
                return;

            if (IsCapture)
            {
                TargetCell.CurrentPiece.Destroy();
            } else if (IsCapturePassant)
            {
                int direction = (Piece.Color == PlayerColor.Black ? -1 : 1);
                board.GetCell(TargetCell.Position.X, TargetCell.Position.Y - direction).CurrentPiece.Destroy();
            } 
            
            Piece.CurrentCell.CurrentPiece = null;
            TargetCell.CurrentPiece = Piece;
            Piece.Position = TargetCell.Position;
        }
        
        private bool IsPassantLegal(Cell previousCell)
        {
            //TODO: check it was the previous move not only the first one but i need to implement turns first
            return 
                TargetCell.IsEmpty && 
                !previousCell.IsEmpty &&
                previousCell.CurrentPiece.Color != Piece.Color &&
                previousCell.CurrentPiece.NumberMovements == 1 &&
                previousCell.CurrentPiece is Pawn;
        }
    }   
}
