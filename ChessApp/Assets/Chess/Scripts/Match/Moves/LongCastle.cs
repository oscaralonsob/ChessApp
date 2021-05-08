using Chess.Match.Pieces;

namespace Chess.Match.Moves
{
    public class LongCastle : Move
    {

        public LongCastle(Piece piece, Cell targetCell, Board board): base(piece, targetCell, board)
        {
        }
        
        public override bool IsLegal()
        {
            if (!IsValid || Piece.Color != Board.ColorTurn)
                return false;
            
            if (!(Piece is King) || Piece.NumberMovements != 0)
            {
                return false;
            }

            if (Piece.Pin != null)
            {
                return false;
            }
            
            Cell middleCell = Board.GetCell(TargetCell.Position + new Coord(1, 0));
            Cell outerCell = Board.GetCell(TargetCell.Position + new Coord(-1, 0));
            if (!FreeCell(TargetCell) || !FreeCell(middleCell) || !FreeCell(outerCell))
            {
                return false;
            }

            Cell rockCell = Board.GetCell(TargetCell.Position + new Coord(-2, 0));
            return rockCell?.CurrentPiece is Rook && rockCell.CurrentPiece.NumberMovements == 0;
        }
        
        protected override void CustomApply()
        {
            Cell rockCell = Board.GetCell(TargetCell.Position + new Coord(-2, 0));
            Cell rockTargetCell = Board.GetCell(TargetCell.Position + new Coord(+1, 0));

            
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
