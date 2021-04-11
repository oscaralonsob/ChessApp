using System;
using System.Collections.Generic;
using Chess.Pieces;

namespace Chess.GameMode
{
    public class GameModeManager
    {
        private IGameMode GameMode { get; set; }
        
        public List<Piece> Pieces { get; set; }
        
        public Board Board { get; set; }

        public GameModeManager(IGameMode gameMode)
        {
            GameMode = gameMode;
            Pieces   = new List<Piece>();
            Board    = new Board();
        }

        public void Setup()
        {
            if (GameMode == null)
            {
                return; 
            }

            foreach (KeyValuePair<Tuple<int, int>, Type> pair in GameMode.PiecePlacement())
            {
                Cell cell = Board.Cells[pair.Key.Item1, pair.Key.Item2];
                Object[] args = {PlayerColor.White, cell};
                Piece piece = (Piece) Activator.CreateInstance(pair.Value, args);
                Pieces.Add(piece);
            }
            
            /*foreach (KeyValuePair<Tuple<int, int>, Type>  pair in GameMode.PiecePlacement())
            {
                Cell cell = Board.Cells[pair.Key.Item1, pair.Key.Item2];
                Object[] args = {PlayerColor.Black, cell};
                Piece piece = (Piece) Activator.CreateInstance(pair.Value, args);
                Pieces.Add(piece);
            }*/
        }
    }
}
