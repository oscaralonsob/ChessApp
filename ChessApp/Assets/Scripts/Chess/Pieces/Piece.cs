using System.Collections.Generic;
using UnityEngine;

namespace Chess.Pieces
{
    public abstract class Piece
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

        public abstract List<Cell> Movement();
    }
}
