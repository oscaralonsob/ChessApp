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
        
        public List<Piece> Pieces { get; }
        
        public List<Piece> CapturedPieces { get; }

        public PlayerColor ColorTurn;
        
        private PlayerColor Winner { get; set; }

        private bool Draw { get; set; }

        public event EventHandler PiecePositionsUpdated;

        public Board()
        {
            Size = 8;
            Pieces = new List<Piece>();
            CapturedPieces = new List<Piece>();
            ColorTurn = PlayerColor.White; 
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
            return (coord.X >= 0 && coord.Y >=0 && coord.X < Size && coord.Y < Size) ? 
                Cells[coord.X, coord.Y] :
                null;
        }
        
        public void SwitchTurn()
        {
            PiecePositionsUpdated?.Invoke(this, EventArgs.Empty);
            ColorTurn = ColorTurn.GetNextPlayerColor();

            UpdatePieceMovement();
            CheckGameOverCondition();
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
            
            UpdatePieceMovement();
        }

        private void UpdatePieceMovement()
        {
            AttackMapGenerator amg = new AttackMapGenerator();
            amg.Generate(this);
            
            MoveGenerator mg = new MoveGenerator();
            mg.Generate(this);
        }
        
        private void CheckGameOverCondition()
        {
            bool hasMoves = Pieces.Any(p => p.Color == ColorTurn && p.Moves.Count != 0);
            if (!hasMoves)
            {
                if (GetKing(ColorTurn).Pin != null)
                {
                    Winner = ColorTurn.GetNextPlayerColor();
                }
                else
                {
                    Draw = true;
                }
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


