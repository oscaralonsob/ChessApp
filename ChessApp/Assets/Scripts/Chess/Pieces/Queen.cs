using System.Collections.Generic;

namespace Chess.Pieces
{
    public class Queen : SlidingPiece
    {
        public Queen(PlayerColor playerColor, Coord coord, Board board) : base(playerColor, coord, board)
        {
        }
        
        public override void GenerateAttackMap()
        {
            GenerateAttackMapRow(0, 1, Board.Size);
            GenerateAttackMapRow(0, -1, Board.Size);
            GenerateAttackMapRow(1, 0, Board.Size);
            GenerateAttackMapRow(-1, 0, Board.Size);
            
            GenerateAttackMapRow(1, 1, Board.Size);
            GenerateAttackMapRow(1, -1, Board.Size);
            GenerateAttackMapRow(-1, 1, Board.Size);
            GenerateAttackMapRow(-1, -1, Board.Size);
        }
        
        public override void UpdateMoves()
        {
            base.UpdateMoves();
            
            StraightPath(0, 1, Board.Size);
            StraightPath(0, -1, Board.Size);
            StraightPath(1, 0, Board.Size);
            StraightPath(-1, 0, Board.Size);
            
            StraightPath(1, 1, Board.Size);
            StraightPath(1, -1, Board.Size);
            StraightPath(-1, 1, Board.Size);
            StraightPath(-1, -1, Board.Size);
        }
    }
}
