using System.Collections.Generic;
using Chess.Match.Pieces;
using UnityEngine;
using UnityEngine.UIElements;

namespace Chess.Match.AI
{
    public interface IMoveGenerator
    {
        public void Generate(Board board, PlayerColor color);
    }
}