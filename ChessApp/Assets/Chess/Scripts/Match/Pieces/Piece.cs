using System.Collections.Generic;
using Controller;
using Chess.Match.Moves;

namespace Chess.Match.Pieces
{
    public abstract class Piece
    {
        public PlayerColor Color { get; }
        
        public Coord Position { get; set; }

        public int NumberMovements { get; set; }
        
        public List<Move> Moves { get; }
        
        public abstract List<RayMove> RayMoves { get; }

        //TODO: new class for pins
        public RayMove Pin { get; set; }

        public bool IsCaptured { get; set; }

        protected Piece(PlayerColor playerColor, Coord coord)
        {
            Color = playerColor;
            Position = coord;
            NumberMovements = 0;
            Moves = new List<Move>();
        }
        
        public string GetSpriteName()
        {
            return "Chess" + GetType().Name + Color;
        }
    }
}
