using System;
using Chess.Pieces;
using Controller;

namespace Chess
{
    public class Cell
    {
        //TODO: I don't like this way to handle communication between unity and logic...
        public CellController CellController { get; set;  }
        public int X { get; }
        public int Y { get; }
        public Board Board { get; }
        
        public Piece CurrentPiece { get; set;  }

        public Cell(int x, int y, Board board)
        {
            X = x;
            Y = y;
            Board = board;
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
