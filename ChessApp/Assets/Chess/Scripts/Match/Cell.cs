using Chess.Match.Pieces;

namespace Chess.Match
{
    public class Cell
    {
        public Coord Position { get; }
        
        public Piece CurrentPiece { get; set; }
        
        public bool IsEmpty => CurrentPiece == null;
        
        public bool IsHighlighted { get; set; }
        
        public bool IsUnderBlackAttack { get; private set; }
        
        public bool IsUnderWhiteAttack { get; private set; }
        
        public Cell(Coord coord)
        {
            Position = coord;
            CurrentPiece = null;
        }

        public void ResetFlags()
        {
            IsUnderBlackAttack = false;
            IsUnderWhiteAttack = false;
        }
        
        public void SetUnderAttack(PlayerColor color)
        {
            if (color == PlayerColor.Black)
            {
                IsUnderBlackAttack = true;
            } else
            {
                IsUnderWhiteAttack = true;
            }
        }
    }   
}
