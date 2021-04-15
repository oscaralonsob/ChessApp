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

        public PlayerColor ColorTurn;

        public Board()
        {
            Size = 8;
            ColorTurn = PlayerColor.White; 
            Cells = new Cell[Size, Size];
            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                   Cells[x, y] = new Cell(x, y, this);
                }
            }
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
                Activator.CreateInstance(pair.Value.Item1, args);
            }
            
            UpdatePieceMovement();
        }

        private void UpdatePieceMovement()
        {
            foreach (Cell cell in Cells)
            {
                cell.CurrentPiece?.UpdateAllowedCells();
            }
        }
    }
    
}


