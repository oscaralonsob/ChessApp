using Chess;
using Chess.Pieces;
using UnityEngine;

namespace Controller
{
    public class BoardController : MonoBehaviour
    {
        public Board Board { get; set; }
        
        public GameObject cellPrefab;
        public GameObject piecePrefab;

        public void Print()
        {
            foreach (Cell cell in Board.Cells)
            {
                // Create the cell
                GameObject newCell = Instantiate(cellPrefab, transform);
            
                // Setup    
                CellController cellController = newCell.GetComponent<CellController>();
                cellController.Cell = cell;
                cell.CellController = cellController;
                cellController.Print();
            }
            
            //TODO: see sorting order
            foreach (Cell cell in Board.Cells)
            {
                if (cell.CurrentPiece != null)
                {
                    GameObject pieceObject = Instantiate(piecePrefab, transform);
                    PieceController pieceController = pieceObject.GetComponent<PieceController>();

                    pieceController.Piece = cell.CurrentPiece;
                    cell.CurrentPiece.PieceController = pieceController;
                    pieceController.Print();
                }
            }
        }
    }
}
