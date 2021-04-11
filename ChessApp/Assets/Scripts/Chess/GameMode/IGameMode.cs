using System;
using System.Collections.Generic;

namespace Chess.GameMode
{
    public interface IGameMode
    {
        Dictionary<Tuple<int, int>, Type> PiecePlacement();
    }
}