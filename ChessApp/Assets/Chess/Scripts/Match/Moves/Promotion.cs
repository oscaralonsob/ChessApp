using Chess.Match.Pieces;
using UnityEngine;

namespace Chess.Match.Moves
{
    public class Promotion : Move
    {
        public Promotion(Piece piece, Cell targetCell, Board board) : base(piece, targetCell, board)
        {
        }
        
        protected override void CustomApply()
        {
            base.CustomApply();
            
            //Remove the current pawn
            Board.Pieces.Remove(Piece);
            //TODO: this is not true, but i needed right now
            Board.CapturedPieces.Add(Piece);
            Piece.IsCaptured = true;
            
            //Create queen
            Queen queen = new Queen(Piece.Color, Piece.Position);
            Board.Pieces.Add(queen);
            TargetCell.CurrentPiece = queen;
            Piece = queen;
        }
    }   
}
