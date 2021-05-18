using System;
using System.Collections.Generic;
using System.Linq;
using Chess.Match.Pieces;
using UnityEngine;
using Object = System.Object;
using Chess.Match.AI;

namespace Chess.Match
{
    public class Board
    {
        public int Size { get; }
        
        public Cell[,] Cells { get; }
        
        //TODO: move pieces to manager
        public List<Piece> Pieces { get; }
        
        public List<Piece> CapturedPieces { get; }
        
        public Board()
        {
            Size = 8;
            Pieces = new List<Piece>();
            CapturedPieces = new List<Piece>();
            Cells = new Cell[Size, Size];
            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                   Cells[x, y] = new Cell(new Coord(x, y));
                }
            }
        }

        public Cell GetCell(int x, int y)
        {
            return (x >= 0 && y >=0 && x < Size && y < Size) ? 
                    Cells[x, y] :
                    null;
        }
        
        public Cell GetCell(Coord coord)
        {
            return GetCell(coord.X, coord.Y);
        }

        public void SetPieces(Dictionary<Vector2Int, Tuple<Type, PlayerColor>> pieces)
        {
            foreach (KeyValuePair<Vector2Int, Tuple<Type, PlayerColor>> pair in pieces)
            {
                Cell cell = Cells[pair.Key.x, pair.Key.y];
                Object[] args = {pair.Value.Item2, cell.Position};
                Piece piece = (Piece) Activator.CreateInstance(pair.Value.Item1, args);
                Pieces.Add(piece);
                cell.CurrentPiece = piece;
            }
        }

        public Piece GetKing(PlayerColor color)
        {
            return Pieces.FirstOrDefault(p => p is King && p.Color == color) as King;
        }
        
        public Piece GetEnemyKing(PlayerColor c)
        {
            PlayerColor color = c == PlayerColor.Black ? PlayerColor.White : PlayerColor.Black;
            return GetKing(color);
        }
    }
}


