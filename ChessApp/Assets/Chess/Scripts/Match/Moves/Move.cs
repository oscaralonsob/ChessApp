using Chess.Match.Pieces;
using UnityEngine;

namespace Chess.Match.Moves
{
    public class Move
    {
        protected Piece Piece { get; }
        
        public Cell TargetCell { get; }

        public bool IsValid => TargetCell != null;
        
        public bool IsLastInPath => !IsValid || !TargetCell.IsEmpty;
        
        private bool IsCapture => IsValid && !TargetCell.IsEmpty && TargetCell.CurrentPiece.Color != Piece.Color;

        public Move(Piece piece, Cell targetCell)
        {
            Piece = piece;
            TargetCell = targetCell;
        }
        
        public virtual bool IsLegal(Board board)
        {
            if (!IsValid || Piece.Color != board.ColorTurn)
                return false;

            //TODO: common method
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

        public virtual void Apply(Board board)
        {
            if (!IsLegal(board) || Piece.Color != board.ColorTurn)
                return;

            if (IsCapture)
            {
                TargetCell.CurrentPiece.Destroy();
            }
            
            Piece.CurrentCell.CurrentPiece = null;
            TargetCell.CurrentPiece = Piece;
            Piece.Position = TargetCell.Position;
        }
    }   
}
