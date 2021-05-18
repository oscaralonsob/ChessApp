using Chess.Match.Pieces;
using UnityEngine;

namespace Chess.Match.Moves
{
    public class Move
    {

        protected Piece Piece { get; set; }
        
        public Cell TargetCell { get; }

        protected bool IsValid => TargetCell != null;
        
        public bool IsLastInPath => !IsValid || !TargetCell.IsEmpty;
        
        private bool IsCapture => IsValid && !TargetCell.IsEmpty && TargetCell.CurrentPiece.Color != Piece.Color;

        public Move(Piece piece, Cell targetCell)
        {
            Piece = piece;
            TargetCell = targetCell;
        }
        
        public virtual bool IsLegal(Board board)
        {
            if (!IsValid)
                return false;

            if (!(Piece is King) && Piece.Pin != null && !Piece.Pin.PointIsInSegment(TargetCell.Position))
            {
                return false;
            }

            Piece king = board.GetKing(Piece.Color);

            if (king == null)
            {
                //Throw error
                return false;
            }

            if (king.Pin != null && !king.Pin.PointIsInSegment(TargetCell.Position) && !(Piece is King))
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
                    return TargetCell.Position.X == pawn.Position.X && TargetCell.IsEmpty ||
                           TargetCell.Position.X != pawn.Position.X && !TargetCell.IsEmpty;
                }

                return true;
            }

            return false;
        }

        public void Apply(Board board)
        {
            CustomApply(board);

            board.GetCell(Piece.Position).CurrentPiece = null;
            TargetCell.CurrentPiece = Piece;
            //Move to piece
            Piece.Position = TargetCell.Position;
            Piece.NumberMovements++;
        }
        
        protected virtual void CustomApply(Board board)
        {
            if (IsCapture)
            {
                Piece targetPiece = TargetCell.CurrentPiece;
                board.Pieces.Remove(targetPiece);
                board.CapturedPieces.Add(targetPiece);
                TargetCell.CurrentPiece = null;
                targetPiece.IsCaptured = true;
            }
        }
    }   
}
