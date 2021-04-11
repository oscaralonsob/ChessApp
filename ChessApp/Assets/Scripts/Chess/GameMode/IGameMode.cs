using System;
using System.Collections.Generic;
using UnityEngine;

namespace Chess.GameMode
{
    public interface IGameMode
    {
        Dictionary<Vector2, Tuple<Type, PlayerColor>> PiecePlacement();
    }
}