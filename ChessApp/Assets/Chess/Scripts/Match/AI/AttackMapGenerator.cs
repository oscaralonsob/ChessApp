using System.Collections.Generic;
using Chess.Match.Pieces;
using UnityEngine;
using UnityEngine.UIElements;

namespace Chess.Match.AI
{
    public class AttackMapGenerator
    {
        private Board Board { get; set; }
        
        public void Generate(Board board)
        {
            Board = board;

            Clear();
            CalculatePieceAttackCells();
        }
        
        private void Clear()
        {
            foreach (Cell cell in Board.Cells)
            {
                cell.ResetFlags();
            }
            
            foreach (Piece piece in Board.Pieces)
            {
                piece.Pin = null;
            }
        }
        
        private void CalculatePieceAttackCells()
        {
            foreach (Piece piece in Board.Pieces)
            {
                foreach (RayMove rayMove in piece.RayMoves)
                {
                    if (rayMove.IsSpecialMove) continue;
                    CalculateAttackFromRayMove(rayMove);
                    if (rayMove.PointIsInSegment(Board.GetEnemyKing(piece.Color).Position))
                    {
                        CalculatePinsFromRayMove(rayMove);
                    }
                }
            }
        }
        
        private void CalculateAttackFromRayMove(RayMove rayMove)
        {
            Cell originCell = Board.GetCell(rayMove.Origin);
            for (int x = 1; x <= rayMove.Range; x++)
            {
                Cell targetCell = Board.GetCell(rayMove.Origin + x * rayMove.Vector);
                
                targetCell?.SetUnderAttack(originCell.CurrentPiece.Color);

                if (targetCell is null || !targetCell.IsEmpty && !(targetCell.CurrentPiece is King))
                {
                    return;
                }
            }
        }

        private void CalculatePinsFromRayMove(RayMove rayMove)
        {
            Piece enemyPieceInPath = null;
            Cell originCell = Board.GetCell(rayMove.Origin);
            for (int x = 1; x <= rayMove.Range; x++)
            {
                Cell targetCell = Board.GetCell(rayMove.Origin + x * rayMove.Vector);

                if (targetCell == null)
                {
                    return;
                }

                if (targetCell.IsEmpty) continue;
                
                if (targetCell.CurrentPiece.Color == originCell.CurrentPiece.Color)
                {
                    return;
                }

                if (targetCell.CurrentPiece is King)
                {
                    if (enemyPieceInPath != null)
                    {
                        enemyPieceInPath.Pin = rayMove;
                    }
                    else
                    {
                        targetCell.CurrentPiece.Pin = new RayMove(rayMove.Origin, rayMove.Vector, x);
                    }
                        
                    return;
                }
                
                if (enemyPieceInPath != null)
                {
                    return;
                }

                enemyPieceInPath = targetCell.CurrentPiece;
            }
        }
    }
}