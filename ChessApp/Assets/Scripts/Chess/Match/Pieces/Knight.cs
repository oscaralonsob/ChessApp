using System.Collections.Generic;
using UnityEngine.Rendering;

namespace Chess.Match.Pieces
{
    public class Knight : Piece
    {
        public Knight(PlayerColor playerColor, Coord coord, Board board) : base(playerColor, coord, board)
        {
        }

        public override void GenerateAttackMap()
        {
            GenerateAttackMapCell(Position.X + 2, Position.Y + 1);
            GenerateAttackMapCell(Position.X + 1, Position.Y + 2);
            GenerateAttackMapCell(Position.X - 2, Position.Y + 1);
            GenerateAttackMapCell(Position.X - 1, Position.Y + 2);
            
            GenerateAttackMapCell(Position.X + 2, Position.Y - 1);
            GenerateAttackMapCell(Position.X + 1, Position.Y - 2);
            GenerateAttackMapCell(Position.X - 2, Position.Y - 1);
            GenerateAttackMapCell(Position.X - 1, Position.Y - 2);
        }

        public override void UpdateMoves()
        {
            base.UpdateMoves();
            
            CreatePath(2, 1);
            CreatePath(1, 2);
            CreatePath(-2, 1);
            CreatePath(-1, 2);
            
            CreatePath(2, -1);
            CreatePath(1, -2);
            CreatePath(-2, -1);
            CreatePath(-1, -2);
        }
    }
}
