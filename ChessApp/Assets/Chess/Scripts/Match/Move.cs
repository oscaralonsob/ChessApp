using Chess.Match.Pieces;
using UnityEngine;

namespace Chess.Match
{
    public class Move
    {
        private Piece Piece { get; }
        
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
            if (!IsValid || Piece.Color != board.ColorTurn)
                return false;

            if (!(Piece is King) && Piece.Pin != null && !Piece.Pin.PointIsInSegment(TargetCell.Position))
            {
                return false;
            }

            Piece king = board.GetKing(Piece.Color);

            if (!(king is King))
            {
                //Game over
                return false;
            }

            if (king.Pin != null && !king.Pin.PointIsInSegment(TargetCell.Position))
            {
                return false;
            }
            
            if (TargetCell.IsEmpty || TargetCell.CurrentPiece.Color != Piece.Color)
            {
                if (Piece is King)
                {                
                    bool targetCellUnderAttack = Piece.Color == PlayerColor.White ? TargetCell.IsUnderBlackAttack : TargetCell.IsUnderWhiteAttack;
                    return !targetCellUnderAttack;
                } 
                
                if (Piece is Pawn pawn)
                {
                    Cell auxCell = board.GetCell(TargetCell.Position.X, TargetCell.Position.Y - pawn.Direction);
                    IsCapturePassant = IsPassantLegal(auxCell);
                    return TargetCell.Position.X == pawn.Position.X && TargetCell.IsEmpty ||
                           TargetCell.Position.X != pawn.Position.X && !TargetCell.IsEmpty || 
                           IsCapturePassant;
                }

                return true;
            }

            return false;
        }

        public void Apply(Board board)
        {
            if (!IsLegal(board) || Piece.Color != board.ColorTurn)
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
