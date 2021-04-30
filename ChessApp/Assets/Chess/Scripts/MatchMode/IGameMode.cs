using System;
using System.Collections.Generic;
using UnityEngine;
using Chess.Match;

namespace Chess.MatchMode
{
    public interface IGameMode
    {
        Dictionary<Vector2Int, Tuple<Type, PlayerColor>> PiecePlacement();
    }
}