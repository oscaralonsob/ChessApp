using Chess.Match.Moves;
using Chess.Match.Pieces;

namespace Chess.Match.AI
{
    public class MoveGenerator
    {
        private Board Board { get; set; }
        
        public void Generate(Board board)
        {
            Board = board;
            
            CalculateMoveCells();
        }

        private void CalculateMoveCells()
        {
            foreach (Piece piece in Board.Pieces)
            {
                piece.Moves.Clear();
                foreach (RayMove rayMove in piece.RayMoves)
                {
                    CalculateMoveFromRayMove(rayMove);
                }
            }
        }

        private void CalculateMoveFromRayMove(RayMove rayMove)
        {
            Piece piece = Board.GetCell(rayMove.Origin).CurrentPiece;
            for (int x = 1; x <= rayMove.Range; x++)
            {
                
                Move move = CreateMoveFromRayMove(piece, rayMove, x);
                
                if (move.IsLegal(Board))
                {
                    piece.Moves.Add(move);
                }

                if (move.IsLastInPath)
                {
                    break;
                }
            }
        }

        //TODO: Factory?
        private Move CreateMoveFromRayMove(Piece piece, RayMove rayMove, int x)
        {
            if (rayMove.IsShortCastle)
            {
                return new ShortCastle(piece, Board.GetCell(rayMove.Origin + x * rayMove.Vector));
            } 
            
            if (rayMove.IsLongCastle)
            {
                return new LongCastle(piece, Board.GetCell(rayMove.Origin + x * rayMove.Vector));
            } 
            
            if (rayMove.IsPassant)
            {
                return new Passant(piece, Board.GetCell(rayMove.Origin + x * rayMove.Vector));
            } 
    
            return new Move(piece, Board.GetCell(rayMove.Origin + x * rayMove.Vector));
        }
    }
}