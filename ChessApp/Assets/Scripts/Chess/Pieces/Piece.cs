using UnityEngine;

namespace Chess.Pieces
{
    public class Piece
    {
        public PlayerColor Color { get; }
        public Cell CurrentCell { get; }

        protected Piece(PlayerColor playerColor, Cell currentCell)
        {
            Color = playerColor;
            CurrentCell = currentCell;
        }
        
        public string GetSpriteName()
        {
            return "Chess" + GetType().Name + Color;
        }
    }
}
