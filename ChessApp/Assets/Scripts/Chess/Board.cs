using System;
using System.Collections.Generic;
using Chess.Pieces;
using UnityEngine;
using Object = System.Object;

namespace Chess
{
    public class Board
    {    
        public Cell[,] Cells { get; }

        //TODO: I think that is better to have the pieces in the cell itself...
        public List<Piece> Pieces { get; set; }

        public Board()
        {
            Pieces = new List<Piece>();
            Cells = new Cell[8, 8];
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                   Cells[x, y] = new Cell(x, y, this);
                }
            }
        }

        public void SetPieces(Dictionary<Vector2Int, Tuple<Type, PlayerColor>> pieces)
        {
            foreach (KeyValuePair<Vector2Int, Tuple<Type, PlayerColor>> pair in pieces)
            {
                Cell cell = Cells[pair.Key.x, pair.Key.y];
                Object[] args = {pair.Value.Item2, cell};
                Piece piece = (Piece) Activator.CreateInstance(pair.Value.Item1, args);
                Pieces.Add(piece);
            }
        }
    }
    
}


