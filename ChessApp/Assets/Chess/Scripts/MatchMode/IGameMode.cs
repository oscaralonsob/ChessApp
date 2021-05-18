using System;
using System.Collections.Generic;
using UnityEngine;
using Chess.Match;
using Chess.Match.AI;

namespace Chess.MatchMode
{
    public interface IGameMode
    {
        Dictionary<Vector2Int, Tuple<Type, PlayerColor>> PiecePlacement { get; }
        IAttackMapGenerator AttackMapGenerator { get; }
        
        IMoveGenerator MoveGenerator { get; }
    }
}