using System.Collections;
using System.Collections.Generic;
using Chess;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    
    public GameObject cellPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        CreateBoard();
    }

    private void CreateBoard()
    {
        Board board = new Board();

        foreach (Cell cell in board.Cells)
        {
            // Create the cell
            GameObject newCell = Instantiate(cellPrefab, transform);
            
            // Setup
            CellController cellController = newCell.GetComponent<CellController>();
            cellController.Setup(cell.X, cell.Y);
        }
    }
}
