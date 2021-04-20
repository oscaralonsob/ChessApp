
namespace Chess.Match.Pieces
{
    public abstract class SlidingPiece : Piece
    {
        protected SlidingPiece(PlayerColor playerColor, Coord coord, Board board) : base(playerColor, coord, board)
        {
        }

        protected void StraightPath(int xDirection, int yDirection, int distance)
        {
            int targetX = CurrentCell.Position.X;
            int targetY = CurrentCell.Position.Y;
            
            for (int x = 1; x <= distance; x++)
            {
                targetX += xDirection;
                targetY += yDirection;
                Move move = new Move(this, Board.GetCell(targetX, targetY));
                
                if (move.IsLegal(Board))
                {
                    Moves.Add(move);
                }

                if (move.IsLastInPath)
                {
                    break;
                }
            }
        }

        public override void UpdateMoves()
        {
            base.UpdateMoves();
            
            StraightPath(0, 1, Board.Size);
            StraightPath(0, -1, Board.Size);
            StraightPath(1, 0, Board.Size);
            StraightPath(-1, 0, Board.Size);
        }
    }
}
