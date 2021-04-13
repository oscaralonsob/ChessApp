﻿using System.Collections.Generic;

namespace Chess.Pieces
{
    public class Queen : Piece
    {
        public Queen(PlayerColor playerColor, Cell currentCell) : base(playerColor, currentCell)
        {
        }

        public override List<Cell> Movement()
        {
            List<Cell> allowedCells = new List<Cell>();

            allowedCells.AddRange(StraightPath(0, 1, CurrentCell.Board.Size));
            allowedCells.AddRange(StraightPath(0, -1, CurrentCell.Board.Size));
            allowedCells.AddRange(StraightPath(1, 0, CurrentCell.Board.Size));
            allowedCells.AddRange(StraightPath(-1, 0, CurrentCell.Board.Size));
            
            allowedCells.AddRange(StraightPath(1, 1, CurrentCell.Board.Size));
            allowedCells.AddRange(StraightPath(1, -1, CurrentCell.Board.Size));
            allowedCells.AddRange(StraightPath(-1, 1, CurrentCell.Board.Size));
            allowedCells.AddRange(StraightPath(-1, -1, CurrentCell.Board.Size));
            
            return allowedCells;
        }
    }
}
