using Chess.Match.Pieces;
using UnityEngine;

namespace Chess.Match.Moves
{
    public class Promotion : Move
    {
        public Promotion(Piece piece, Cell targetCell) : base(piece, targetCell)
        {
        }
        
        protected override void CustomApply(Board board)
        {
            base.CustomApply(board);
            
            //Remove the current pawn
            board.Pieces.Remove(Piece);
            //TODO: this is not true, but i needed right now
            board.CapturedPieces.Add(Piece);
            Piece.IsCaptured = true;
            
            //Create queen
            Queen queen = new Queen(Piece.Color, Piece.Position);
            board.Pieces.Add(queen);
            TargetCell.CurrentPiece = queen;
            Piece = queen;
        }
    }   
}
