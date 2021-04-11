using System;
using System.Collections.Generic;
using Chess.Pieces;
using UnityEngine;

namespace Chess.GameMode
{
    public class NormalGameMode : IGameMode
    {
        public Dictionary<Vector2Int, Tuple<Type, PlayerColor>> PiecePlacement()
        {
            return new Dictionary<Vector2Int, Tuple<Type, PlayerColor>>
            {
                {new Vector2Int(0,0), new Tuple<Type, PlayerColor>(typeof(Rook), PlayerColor.White)},
                {new Vector2Int(1,0), new Tuple<Type, PlayerColor>(typeof(Knight), PlayerColor.White)},
                {new Vector2Int(2,0), new Tuple<Type, PlayerColor>(typeof(Bishop), PlayerColor.White)},
                {new Vector2Int(3,0), new Tuple<Type, PlayerColor>(typeof(Queen), PlayerColor.White)},
                {new Vector2Int(4,0), new Tuple<Type, PlayerColor>(typeof(King), PlayerColor.White)},
                {new Vector2Int(5,0), new Tuple<Type, PlayerColor>(typeof(Bishop), PlayerColor.White)},
                {new Vector2Int(6,0), new Tuple<Type, PlayerColor>(typeof(Knight), PlayerColor.White)},
                {new Vector2Int(7,0), new Tuple<Type, PlayerColor>(typeof(Rook), PlayerColor.White)},
                {new Vector2Int(0,1), new Tuple<Type, PlayerColor>(typeof(Pawn), PlayerColor.White)},
                {new Vector2Int(1,1), new Tuple<Type, PlayerColor>(typeof(Pawn), PlayerColor.White)},
                {new Vector2Int(2,1), new Tuple<Type, PlayerColor>(typeof(Pawn), PlayerColor.White)},
                {new Vector2Int(3,1), new Tuple<Type, PlayerColor>(typeof(Pawn), PlayerColor.White)},
                {new Vector2Int(4,1), new Tuple<Type, PlayerColor>(typeof(Pawn), PlayerColor.White)},
                {new Vector2Int(5,1), new Tuple<Type, PlayerColor>(typeof(Pawn), PlayerColor.White)},
                {new Vector2Int(6,1), new Tuple<Type, PlayerColor>(typeof(Pawn), PlayerColor.White)},
                {new Vector2Int(7,1), new Tuple<Type, PlayerColor>(typeof(Pawn), PlayerColor.White)},
                
                {new Vector2Int(0,7), new Tuple<Type, PlayerColor>(typeof(Rook), PlayerColor.Black)},
                {new Vector2Int(1,7), new Tuple<Type, PlayerColor>(typeof(Knight), PlayerColor.Black)},
                {new Vector2Int(2,7), new Tuple<Type, PlayerColor>(typeof(Bishop), PlayerColor.Black)},
                {new Vector2Int(3,7), new Tuple<Type, PlayerColor>(typeof(Queen), PlayerColor.Black)},
                {new Vector2Int(4,7), new Tuple<Type, PlayerColor>(typeof(King), PlayerColor.Black)},
                {new Vector2Int(5,7), new Tuple<Type, PlayerColor>(typeof(Bishop), PlayerColor.Black)},
                {new Vector2Int(6,7), new Tuple<Type, PlayerColor>(typeof(Knight), PlayerColor.Black)},
                {new Vector2Int(7,7), new Tuple<Type, PlayerColor>(typeof(Rook), PlayerColor.Black)},
                {new Vector2Int(0,6), new Tuple<Type, PlayerColor>(typeof(Pawn), PlayerColor.Black)},
                {new Vector2Int(1,6), new Tuple<Type, PlayerColor>(typeof(Pawn), PlayerColor.Black)},
                {new Vector2Int(2,6), new Tuple<Type, PlayerColor>(typeof(Pawn), PlayerColor.Black)},
                {new Vector2Int(3,6), new Tuple<Type, PlayerColor>(typeof(Pawn), PlayerColor.Black)},
                {new Vector2Int(4,6), new Tuple<Type, PlayerColor>(typeof(Pawn), PlayerColor.Black)},
                {new Vector2Int(5,6), new Tuple<Type, PlayerColor>(typeof(Pawn), PlayerColor.Black)},
                {new Vector2Int(6,6), new Tuple<Type, PlayerColor>(typeof(Pawn), PlayerColor.Black)},
                {new Vector2Int(7,6), new Tuple<Type, PlayerColor>(typeof(Pawn), PlayerColor.Black)},
            };
        }
        
    }
}