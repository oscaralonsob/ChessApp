using Chess.Match.Pieces;
using UnityEngine;

namespace Chess.Match.Moves
{
    public class Move
    {
        protected Board Board { get; }
        
        protected Piece Piece { get; set; }
        
        public Cell TargetCell { get; }

        protected bool IsValid => TargetCell != null;
        
        public bool IsLastInPath => !IsValid || !TargetCell.IsEmpty;
        
        private bool IsCapture => IsValid && !TargetCell.IsEmpty && TargetCell.CurrentPiece.Color != Piece.Color;

        public Move(Piece piece, Cell targetCell, Board board)
        {
            Piece = piece;
            TargetCell = targetCell;
            Board = board;
        }
        
        public virtual bool IsLegal()
        {
            if (!IsValid)
                return false;

            if (!(Piece is King) && Piece.Pin != null && !Piece.Pin.PointIsInSegment(TargetCell.Position))
            {
                return false;
            }

            Piece king = Board.GetKing(Piece.Color);

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

        public void Apply()
        {
            if (!IsLegal())
                return;

            CustomApply();

            Board.GetCell(Piece.Position).CurrentPiece = null;
            TargetCell.CurrentPiece = Piece;
            Piece.Position = TargetCell.Position;
            Piece.NumberMovements++;
            
            Board.SwitchTurn();
        }
        
        protected virtual void CustomApply()
        {
            if (IsCapture)
            {
                Piece targetPiece = TargetCell.CurrentPiece;
                Board.Pieces.Remove(targetPiece);
                Board.CapturedPieces.Add(targetPiece);
                TargetCell.CurrentPiece = null;
                targetPiece.IsCaptured = true;
            }
        }
    }   
}
