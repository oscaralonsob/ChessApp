using Chess.Match.Pieces;

namespace Chess.Match.Moves
{
    public class LongCastle : Move
    {

        public LongCastle(Piece piece, Cell targetCell): base(piece, targetCell)
        {
        }
        
        public override bool IsLegal(Board board)
        {
            if (!IsValid || Piece.Color != board.ColorTurn)
                return false;
            
            if (!(Piece is King) || Piece.NumberMovements != 0)
            {
                return false;
            }

            if (Piece.Pin != null)
            {
                return false;
            }
            
            Cell middleCell = board.GetCell(TargetCell.Position + new Coord(1, 0));
            Cell outerCell = board.GetCell(TargetCell.Position + new Coord(-1, 0));
            if (!FreeCell(TargetCell) || !FreeCell(middleCell) || !FreeCell(outerCell))
            {
                return false;
            }

            Cell rockCell = board.GetCell(TargetCell.Position + new Coord(-2, 0));
            return rockCell?.CurrentPiece is Rook && rockCell.CurrentPiece.NumberMovements == 0;
        }
        
        public override void Apply(Board board)
        {
            if (!IsLegal(board))
                return;

            Piece.CurrentCell.CurrentPiece = null;
            TargetCell.CurrentPiece = Piece;
            Piece.Position = TargetCell.Position;
            
            Cell rockCell = board.GetCell(TargetCell.Position + new Coord(-2, 0));
            Cell rockTargetCell = board.GetCell(TargetCell.Position + new Coord(+1, 0));

            
            rockTargetCell.CurrentPiece = rockCell.CurrentPiece;
            rockTargetCell.CurrentPiece.Position = rockTargetCell.Position;
            rockCell.CurrentPiece = null;
        }

        //TODO: move to cell class
        private bool FreeCell(Cell cell)
        {
            bool cellUnderAttack = Piece.Color == PlayerColor.White ? cell.IsUnderBlackAttack : cell.IsUnderWhiteAttack;
            return cell.IsEmpty && !cellUnderAttack;
        }
    }   
}
