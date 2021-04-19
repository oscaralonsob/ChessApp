using System.Collections.Generic;

namespace Chess.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(PlayerColor playerColor, Coord coord, Board board) : base(playerColor, coord, board)
        {
        }

        public override void GenerateAttackMap()
        {
            GenerateAttackMapRow(1, 1, Board.Size);
            GenerateAttackMapRow(1, -1, Board.Size);
            GenerateAttackMapRow(-1, 1, Board.Size);
            GenerateAttackMapRow(-1, -1, Board.Size);
        }

        public override void UpdateMoves()
        {
            base.UpdateMoves();
            
            StraightPath(1, 1, Board.Size);
            StraightPath(1, -1, Board.Size);
            StraightPath(-1, 1, Board.Size);
            StraightPath(-1, -1, Board.Size);
        }
    }
}
