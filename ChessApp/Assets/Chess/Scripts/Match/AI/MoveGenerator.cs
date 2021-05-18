using Chess.Match.Moves;
using Chess.Match.Pieces;

namespace Chess.Match.AI
{
    public class MoveGenerator : IMoveGenerator
    {
        private Board Board { get; set; }
        
        public void Generate(Board board, PlayerColor color)
        {
            Board = board;
            ClearPreCalculatedMoveCells();
            CalculateMoveCells(color);
        }
        
        private void ClearPreCalculatedMoveCells()
        {
            foreach (Piece piece in Board.Pieces)
            {
                piece.Moves.Clear();
            }
        }

        private void CalculateMoveCells(PlayerColor color)
        {
            foreach (Piece piece in Board.Pieces.FindAll(p => p.Color == color))
            {
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
            
            if (piece is Pawn pawn)
            {
                int targetY = (rayMove.Origin + x * rayMove.Vector).Y;
                if (pawn.Color == PlayerColor.White && targetY == Board.Size - 1||
                    pawn.Color == PlayerColor.Black && targetY == 0)
                {
                    return new Promotion(piece, Board.GetCell(rayMove.Origin + x * rayMove.Vector));
                }
                
            } 
    
            return new Move(piece, Board.GetCell(rayMove.Origin + x * rayMove.Vector));
        }
    }
}