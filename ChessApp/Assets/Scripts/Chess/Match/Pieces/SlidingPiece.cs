
namespace Chess.Match.Pieces
{
    public abstract class SlidingPiece : Piece
    {
        //TODO: I think this can be deleted rn
        protected SlidingPiece(PlayerColor playerColor, Coord coord, Board board) : base(playerColor, coord, board)
        {
        }
    }
}
