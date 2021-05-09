using System;
using System.Collections.Generic;
using Chess.Match.Pieces;
using Controller;

namespace Chess.Match
{
    public class Cell
    {
        //TODO: can i remove this?
        public CellController CellController { get; set;  }
        
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
