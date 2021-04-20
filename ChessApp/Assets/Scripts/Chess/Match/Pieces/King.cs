using System.Collections.Generic;
using UnityEngine;

namespace Chess.Match.Pieces
{
    public class King : SlidingPiece
    {
        //TODO: castle
        public King(PlayerColor playerColor, Coord coord, Board board) : base(playerColor, coord, board)
        {
        }
        
        //TODO: no castle
        public override List<RayMove> RayMoves
            => new List<RayMove>
            {
                new RayMove(Position, new Coord(0,1), 1),
                new RayMove(Position, new Coord(0,-1), 1),
                new RayMove(Position, new Coord(1,0), 1),
                new RayMove(Position, new Coord(-1,0), 1),
                new RayMove(Position, new Coord(1,1), 1),
                new RayMove(Position, new Coord(1,-1), 1),
                new RayMove(Position, new Coord(-1,1), 1),
                new RayMove(Position, new Coord(-1,-1), 1),
            };

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
