using System;
using Chess.Pieces;
using Controller;

namespace Chess
{
    public class Cell
    {
        public CellController CellController { get; set;  }
        
        public Coord Position { get; }
        public Piece CurrentPiece { get; set; }
        
        public bool IsEmpty => CurrentPiece == null;

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
    }   
}
