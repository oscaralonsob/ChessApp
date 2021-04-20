using System.Collections.Generic;
using UnityEngine;

namespace Chess.Match.Pieces
{
    public class Bishop : SlidingPiece
    {
        public Bishop(PlayerColor playerColor, Coord coord, Board board) : base(playerColor, coord, board)
        {
        }

        public override List<RayMove> RayMoves
            => new List<RayMove>
            {
                new RayMove(Position, new Coord(1,1), Board.Size),
                new RayMove(Position, new Coord(1,-1), Board.Size),
                new RayMove(Position, new Coord(-1,1), Board.Size),
                new RayMove(Position, new Coord(-1,-1), Board.Size),
            };

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
