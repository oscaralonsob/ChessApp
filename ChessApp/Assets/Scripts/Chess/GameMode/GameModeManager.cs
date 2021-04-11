using System;
using System.Collections.Generic;
using Chess.Pieces;
using UnityEngine;
using Object = System.Object;

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

            foreach (KeyValuePair<Vector2Int, Tuple<Type, PlayerColor>> pair in GameMode.PiecePlacement())
            {
                Cell cell = Board.Cells[pair.Key.x, pair.Key.y];
                Object[] args = {pair.Value.Item2, cell};
                Piece piece = (Piece) Activator.CreateInstance(pair.Value.Item1, args);
                Pieces.Add(piece);
            }
        }
    }
}
