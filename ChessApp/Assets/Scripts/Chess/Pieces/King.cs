using System.Collections.Generic;
using UnityEngine;

namespace Chess.Pieces
{
    public class King : SlidingPiece
    {
        //TODO: castle
        public King(PlayerColor playerColor, Coord coord, Board board) : base(playerColor, coord, board)
        {
        }
        
        public override void GenerateAttackMap()
        {
            GenerateAttackMapRow(0, 1, 1);
            GenerateAttackMapRow(0, -1, 1);
            GenerateAttackMapRow(1, 0, 1);
            GenerateAttackMapRow(-1, 0, 1);
            
            GenerateAttackMapRow(1, 1, 1);
            GenerateAttackMapRow(1, -1, 1);
            GenerateAttackMapRow(-1, 1, 1);
            GenerateAttackMapRow(-1, -1, 1);
        }
        
        public override void UpdateMoves()
        {
            base.UpdateMoves();
            
            StraightPath(0, 1, 1);
            StraightPath(0, -1, 1);
            StraightPath(1, 0, 1);
            StraightPath(-1, 0, 1);
            
            StraightPath(1, 1, 1);
            StraightPath(1, -1, 1);
            StraightPath(-1, 1, 1);
            StraightPath(-1, -1, 1);
        }
    }
}
