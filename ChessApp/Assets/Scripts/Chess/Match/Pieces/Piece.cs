using System.Collections.Generic;
using Controller;

namespace Chess.Match.Pieces
{
    public abstract class Piece
    {
        public PieceController PieceController { get; set; }
        
        public PlayerColor Color { get; }
        
        public Coord Position { get; set; }
        
        protected Board Board { get; }
        
        public Cell CurrentCell => Board.Cells[Position.X, Position.Y];
        
        public int NumberMovements { get; private set; }
        
        public List<Move> Moves { get; }
        
        public abstract List<RayMove> RayMoves { get; }

        public bool IsUnderAttack => Color == PlayerColor.White ? CurrentCell.IsUnderBlackAttack : CurrentCell.IsUnderWhiteAttack;

        public bool IsMyTurn => Board.ColorTurn == Color;
        
        public bool IsPined { get; set; }

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
        
        public void Move(Move move)
        {
            if (move.IsValid)
            {
                move.Apply(Board);
                NumberMovements++;
                Board.SwitchTurn();
            }
        }

        public void Destroy()
        {
            Board.Pieces.Remove(this);
            CurrentCell.CurrentPiece = null;
            PieceController.Destroy();
        }
    }
}
