using System.Collections.Generic;
using Chess.Match.Pieces;
using UnityEngine;
using UnityEngine.UIElements;

namespace Chess.Match.AI
{
    public interface IAttackMapGenerator
    {
        public void Generate(Board board);
    }
}