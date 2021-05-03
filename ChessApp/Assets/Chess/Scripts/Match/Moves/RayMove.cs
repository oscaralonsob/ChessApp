namespace Chess.Match
{
    public class RayMove
    {
        public Coord Origin { get; }
        
        public Coord Vector { get; }
        
        public int Range { get; }
        //TODO: first try of special movements, needs a refactor
        public bool IsCapture { get; set; }
        
        public bool IsShortCastle { get; set; }
        
        public bool IsLongCastle { get; set; }

        public bool IsPassant { get; set; }

        public bool IsSpecialMove => !IsCapture || IsLongCastle || IsShortCastle || IsPassant;

        public RayMove(Coord origin, Coord vector, int range)
        {
            Origin = origin;
            Vector = vector;
            Range = range;
            IsCapture = true;
        }

        public bool PointIsInSegment(Coord toCheck)
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
