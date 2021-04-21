using Chess.Match.Pieces;

namespace Chess.Match
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
                Move move = new Move(piece, Board.GetCell(rayMove.Origin + x * rayMove.Vector));
                
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
    }
}