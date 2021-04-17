using System;
using System.Collections.Generic;
using Chess.Pieces;
using UnityEngine;
using Object = System.Object;

namespace Chess
{
    public class Board
    {
        public int Size { get; }
        public Cell[,] Cells { get; }

        public List<Piece> Pieces { get; }

        public PlayerColor ColorTurn;

        public Board()
        {
            Size = 8;
            Pieces = new List<Piece>();
            ColorTurn = PlayerColor.White; 
            Cells = new Cell[Size, Size];
            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                   Cells[x, y] = new Cell(new Coord(x, y), this);
                }
            }
        }

        public Cell GetCell(int x, int y)
        {
            return (x >= 0 && y >=0 && x < Size && y < Size) ? 
                    Cells[x, y] :
                    null;
        }
        
        public void SwitchTurn()
        {
            ColorTurn = ColorTurn == PlayerColor.White
                ? PlayerColor.Black
                : PlayerColor.White;

            UpdatePieceMovement();
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
            
            UpdatePieceMovement();
        }

        private void UpdatePieceMovement()
        {
            foreach (Cell cell in Cells)
            {
                cell.CurrentPiece?.UpdateAllowedCells();
            }
            
            foreach (Piece piece in Pieces)
            {
                foreach (Cell cell in piece.AllowedCells)
                {
                    if (cell.CurrentPiece != null && cell.CurrentPiece.Color != piece.Color)
                    {
                        cell.CurrentPiece.IsUnderAttack = true;
                    }
                }
            }
        }
    }
    
}


