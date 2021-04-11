using System;
using System.Collections.Generic;
using UnityEngine;

namespace Chess.GameMode
{
    public interface IGameMode
    {
        Dictionary<Vector2Int, Tuple<Type, PlayerColor>> PiecePlacement();
    }
}