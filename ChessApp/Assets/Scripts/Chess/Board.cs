namespace Chess
{
    public class Board
    {    
        public Cell[,] Cells { get; }

        public Board()
        {
            Cells = new Cell[8, 8];
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                   Cells[x, y] = new Cell(x, y);
                }
            }
        }
    }
    
}


