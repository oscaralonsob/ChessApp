namespace Chess
{
    public class Board
    {    
        public Cell[,] Cells { get; }

        public Board()
        {
            Cells = new Cell[8, 8];
            Cell cell;
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                   cell = new Cell(x, y);
                   Cells[x, y] = cell;
                }
            }
        }
    }
    
}


