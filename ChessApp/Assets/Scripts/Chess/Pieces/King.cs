using System.Collections.Generic;

namespace Chess.Pieces
{
    public class King : Piece
    {
        public King(PlayerColor playerColor, Cell currentCell) : base(playerColor, currentCell)
        {
        }

        public override List<Cell> Movement()
        {
            throw new System.NotImplementedException();
        }
    }
}
