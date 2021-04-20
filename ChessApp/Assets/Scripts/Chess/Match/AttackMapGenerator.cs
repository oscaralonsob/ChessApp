using System.Collections.Generic;
using Chess.Match.Pieces;

namespace Chess.Match
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
        }
        
        private void CalculatePieceAttackCells()
        {
            foreach (Piece piece in Board.Pieces)
            {
                foreach (RayMove rayMove in piece.RayMoves)
                {
                    CalculateAttackFromRayMove(rayMove);
                }
            }
        }

        private void CalculateAttackFromRayMove(RayMove rayMove)
        {
            Piece enemyPieceInPath = null;
            bool pathBlocked = false;
            
            Cell originCell = Board.GetCell(rayMove.Origin);
            for (int x = 1; x <= rayMove.Range; x++)
            {
                Cell targetCell = Board.GetCell(rayMove.Origin + rayMove.Vector);

                if (targetCell == null)
                {
                    break;
                }
                
                if (!pathBlocked)
                {
                    targetCell.SetUnderAttack(originCell.CurrentPiece.Color);
                }

                if (!targetCell.IsEmpty)
                {
                    pathBlocked = true;
                }

                if (!targetCell.IsEmpty && targetCell.CurrentPiece.Color != originCell.CurrentPiece.Color)
                {
                    if (enemyPieceInPath == null)
                    {
                        enemyPieceInPath = targetCell.CurrentPiece;
                        //targetCell.CurrentPiece.IsPined = true;
                    } else if (targetCell.CurrentPiece is King)
                    {
                        break;
                    } else
                    {
                        //enemyPieceInPath.IsPined = false;
                        break;
                    }
                }
            }
        }
    }
}