using System;
using System.Collections.Generic;
using Chess.Match.Pieces;
using Controller;

namespace Chess.Match
{
    public class Cell
    {
        public CellController CellController { get; set;  }
        
        public Coord Position { get; }
        
        public Piece CurrentPiece { get; set; }
        
        public bool IsEmpty => CurrentPiece == null;
        
        public bool IsUnderBlackAttack { get; set; }
        
        public bool IsUnderWhiteAttack { get; set; }

        public Cell(Coord coord)
        {
            Position = coord;
            CurrentPiece = null;
        }

        //Communication between game logic and GameEngine logic
        public void HighlightCell()
        {
            if (CellController)
            {
                CellController.HighlightCell();
            }
        }
        
        //Communication between game logic and GameEngine logic
        public void ClearHighlightCell()
        {
            if (CellController)
            {
                CellController.ClearHighlightCell();
            }
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
