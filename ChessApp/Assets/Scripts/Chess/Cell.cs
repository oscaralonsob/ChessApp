using System;
using Chess.Pieces;
using Controller;

namespace Chess
{
    public class Cell
    {
        public CellController CellController { get; set;  }
        public int X { get; }
        public int Y { get; }
        public Board Board { get; }
        public Piece CurrentPiece { get; set;  }
        
        public bool IsEmpty => CurrentPiece == null;

        public Cell(int x, int y, Board board)
        {
            X = x;
            Y = y;
            Board = board;
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
