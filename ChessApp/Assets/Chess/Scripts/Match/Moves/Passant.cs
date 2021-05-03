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
            if (!IsValid || Piece.Color != board.ColorTurn)
                return false;
            
            //TODO: common method
            if (!(Piece is Pawn pawn))
            {
                return false;
            }
            
            //TODO: common method
            if (Piece.Pin != null && !Piece.Pin.PointIsInSegment(TargetCell.Position))
            {
                return false;
            }

            Cell previousCell = board.GetCell(TargetCell.Position + new Coord(0, -pawn.Direction));
            if (TargetCell.IsEmpty &&
                !previousCell.IsEmpty &&
                previousCell.CurrentPiece.Color != Piece.Color &&
                previousCell.CurrentPiece.NumberMovements == 1)
            {
                return true;
            }

            return false;
        }
        
        public override void Apply(Board board)
        {
            if (!IsLegal(board) || Piece.Color != board.ColorTurn)
                return;
            
            //TODO: common method
            if (!(Piece is Pawn pawn))
            {
                return;
            }
            
            board.GetCell(TargetCell.Position.X, TargetCell.Position.Y - pawn.Direction).CurrentPiece.Destroy();

            Piece.CurrentCell.CurrentPiece = null;
            TargetCell.CurrentPiece = Piece;
            Piece.Position = TargetCell.Position;
        }
    }   
}
