using Chess.Match.Pieces;

namespace Chess.Match.Moves
{
    public class ShortCastle : Move
    {

        public ShortCastle(Piece piece, Cell targetCell): base(piece, targetCell)
        {
        }
        
        public override bool IsLegal(Board board)
        {
            if (!IsValid)
                return false;
            
            if (!(Piece is King) || Piece.NumberMovements != 0)
            {
                return false;
            }

            if (Piece.Pin != null)
            {
                return false;
            }
            
            Cell middleCell = board.GetCell(TargetCell.Position + new Coord(-1, 0));
            if (!FreeCell(TargetCell) || !FreeCell(middleCell))
            {
                return false;
            }

            Cell rockCell = board.GetCell(TargetCell.Position + new Coord(1, 0));
            return rockCell?.CurrentPiece is Rook && rockCell.CurrentPiece.NumberMovements == 0;
        }
        
        protected override void CustomApply(Board board)
        {
            Cell rockCell = board.GetCell(TargetCell.Position + new Coord(1, 0));
            Cell rockTargetCell = board.GetCell(TargetCell.Position + new Coord(-1, 0));

            
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
