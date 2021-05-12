using Chess.Match.Pieces;

namespace Chess.Match.Moves
{
    public class Passant : Move
    {

        public Passant(Piece piece, Cell targetCell, Board board): base(piece, targetCell, board)
        {
        }
        
        public override bool IsLegal()
        {
            if (!IsValid || Piece.Color != Board.ColorTurn)
                return false;
            
            if (!(Piece is Pawn pawn))
                return false;
            
            if (Piece.Pin != null && !Piece.Pin.PointIsInSegment(TargetCell.Position))
                return false;

            Cell previousCell = Board.GetCell(TargetCell.Position + new Coord(0, -pawn.Direction));
            if (TargetCell.IsEmpty &&
                !previousCell.IsEmpty &&
                previousCell.CurrentPiece.Color != Piece.Color &&
                previousCell.CurrentPiece.NumberMovements == 1 &&
                previousCell.CurrentPiece is Pawn)
            {
                return true;
            }

            return false;
        }
        
        protected override void CustomApply()
        {
            //I know is a pawn in this point
            Pawn pawn = Piece as Pawn;
            Piece targetPiece = Board.GetCell(TargetCell.Position.X, TargetCell.Position.Y - pawn.Direction).CurrentPiece;
            Board.Pieces.Remove(targetPiece);
            Board.CapturedPieces.Add(targetPiece);
            TargetCell.CurrentPiece = null;
            targetPiece.IsCaptured = true;
        }
    }   
}
