using System;
using Chess.Match.Pieces;
using UnityEngine;

namespace Chess.Match
{
    public class RayMove
    {
        public Coord Origin { get; }
        
        public Coord Vector { get; }
        
        public int Range { get; }
        
        private Board Board { get; }
        
        public bool IsEnemyKingInRange { get; }

        public RayMove(Coord origin, Coord vector, int range, Board board)
        {
            Origin = origin;
            Vector = vector;
            Range = range;
            Board = board;

            IsEnemyKingInRange = RayCastOverEnemyKing();
        }

        private bool RayCastOverEnemyKing()
        {
            
            Cell originCell = Board.GetCell(Origin);
            Piece piece = originCell.CurrentPiece;
            Piece enemyKing = Board.GetKing(piece.Color == PlayerColor.Black ? PlayerColor.White : PlayerColor.Black);

            return PointIsInSegment(enemyKing.Position);
        }

        //TODO: probably there is a better way to do this but it works
        private bool PointIsInSegment(Coord toCheck)
        {
            Coord end = Origin + Range * Vector;
            bool collinear = (end.X - Origin.X) * (toCheck.Y - Origin.Y) == (toCheck.X - Origin.X) * (end.Y - Origin.Y);

            if (!collinear)
                return false;

            if (Origin.Y == end.Y)
                return Origin.X <= toCheck.X && toCheck.X <= end.X || Origin.X >= toCheck.X && toCheck.X >= end.X;
            
            return Origin.Y <= toCheck.Y && toCheck.Y <= end.Y || Origin.Y >= toCheck.Y && toCheck.Y >= end.Y;
        }
    }   
}
