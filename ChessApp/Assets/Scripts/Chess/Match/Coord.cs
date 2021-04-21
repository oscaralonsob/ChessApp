namespace Chess.Match
{
    public class Coord
    {
        public int X { get; }
        
        public int Y { get; }

        public Coord(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Coord operator+(Coord a, Coord b)
        {
            return new Coord(a.X + b.X,a.Y + b.Y);
        }
        
        public static Coord operator*(int a, Coord b)
        {
            return new Coord(a * b.X,a * b.Y);
        }
    }   
}
