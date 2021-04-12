using System;

namespace Chess
{
    public class Cell
    {
        public event EventHandler HighlightCellEvent;
        public int X { get; }
        public int Y { get; }
        public Board Board { get; }

        public Cell(int x, int y, Board board)
        {
            X = x;
            Y = y;
            Board = board;
        }

        //Communication between game logic and GameEngine logic
        public void HighlightCell()
        {
            HighlightCellEvent?.Invoke(this, EventArgs.Empty);
        }
    }   
}
