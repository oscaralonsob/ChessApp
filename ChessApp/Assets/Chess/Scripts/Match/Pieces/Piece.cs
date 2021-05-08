using System.Collections.Generic;
using Controller;
using Chess.Match.Moves;

namespace Chess.Match.Pieces
{
    public abstract class Piece
    {
        public PieceController PieceController { get; set; }
        
        public PlayerColor Color { get; }
        
        public Coord Position { get; set; }
        
        protected Board Board { get; }
        
        public Cell CurrentCell => Board.Cells[Position.X, Position.Y];
        
        public int NumberMovements { get; set; }
        
        public List<Move> Moves { get; }
        
        public abstract List<RayMove> RayMoves { get; }

        public RayMove Pin { get; set; }

        protected Piece(PlayerColor playerColor, Coord coord, Board board)
        {
            Color = playerColor;
            Board = board;
            Position = coord;
            CurrentCell.CurrentPiece = this;
            NumberMovements = 0;
            Moves = new List<Move>();
        }
        
        public string GetSpriteName()
        {
            return "Chess" + GetType().Name + Color;
        }
    }
}
