using System;
using System.Collections.Generic;
using Chess.Pieces;
using UnityEngine;
using Object = System.Object;

namespace Chess.GameMode
{
    public class GameModeManager
    {
        public Board Board { get; }

        public GameModeManager(IGameMode gameMode)
        {
            Board    = new Board();
            Board.SetPieces(gameMode.PiecePlacement());
        }
    }
}
