using Chess.Match.Pieces;

namespace Chess.Match.Moves
{
    public class Passant : Move
    {

        public Passant(Piece piece, Cell targetCell): base(piece, targetCell)
        {
        }
        
        public override bool IsLegal(Board board)
        {
            if (!IsValid)
                return false;
            
            if (!(Piece is Pawn pawn))
                return false;
            
            if (Piece.Pin != null && !Piece.Pin.PointIsInSegment(TargetCell.Position))
                return false;

            Cell previousCell = board.GetCell(TargetCell.Position + new Coord(0, -pawn.Direction));
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
        
        protected override void CustomApply(Board board)
        {
            //I know is a pawn in this point
            Pawn pawn = Piece as Pawn;
            Piece targetPiece = board.GetCell(TargetCell.Position.X, TargetCell.Position.Y - pawn.Direction).CurrentPiece;
            board.Pieces.Remove(targetPiece);
            board.CapturedPieces.Add(targetPiece);
            TargetCell.CurrentPiece = null;
            targetPiece.IsCaptured = true;
        }
    }   
}
