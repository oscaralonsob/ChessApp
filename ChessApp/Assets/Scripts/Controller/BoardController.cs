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
            
            //TODO: do this inside the cell itself
            foreach (Piece piece in Board.Pieces)
            {
                GameObject pieceObject = Instantiate(piecePrefab, transform);
                PieceController pieceController = pieceObject.GetComponent<PieceController>();

                pieceController.Piece = piece;
                piece.PieceController = pieceController;
                pieceController.Print();
            }
        }
    }
}
