using Chess;
using UnityEngine;

namespace Controller
{
    public class BoardController : MonoBehaviour
    {
        public Board Board { get; set; }
        
        public GameObject cellPrefab;

        public void Print()
        {
            foreach (Cell cell in Board.Cells)
            {
                // Create the cell
                GameObject newCell = Instantiate(cellPrefab, transform);
            
                // Setup
                CellController cellController = newCell.GetComponent<CellController>();
                cellController.Cell = cell;
                cellController.Print();
            }
        }
    }
}
