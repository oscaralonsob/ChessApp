using System.Collections.Generic;
using Chess.Match;
using Chess.Match.Pieces;
using UnityEngine;

namespace Chess.Controller
{
    public class BoardController : MonoBehaviour, IGUIController
    {
        public Board Board { get; set; }

        private Dictionary<Piece, IGUIController> PieceGUIControllers { get; } = new Dictionary<Piece, IGUIController>();
        
        public GameObject cellPrefab;
        
        public GameObject piecePrefab;

        public void Init()
        {
            float size = GetCellSize();
            
            UpdateCellsGUI(size);
            UpdatePiecesGUI(size);
        }

        public void UpdateGUI(float size = 0)
        {
            if (Board == null) return;
            
            size = size != 0 ? size : GetCellSize();
            UpdatePiecesGUI(size);
        }
        
        private void UpdateCellsGUI(float size)
        {
            foreach (Cell cell in Board.Cells)
            {
                GameObject newCell = Instantiate(cellPrefab, transform);
            
                CellController cellController = newCell.GetComponent<CellController>();
                cellController.Cell = cell;
                cellController.UpdateGUI(size);
            }
        }

        private void UpdatePiecesGUI(float size)
        {
            List<Piece> allPieces = new List<Piece>();
            
            allPieces.AddRange(Board.Pieces);
            allPieces.AddRange(Board.CapturedPieces);
            
            foreach (Piece piece in allPieces)
            {
                if (!PieceGUIControllers.ContainsKey(piece))
                {
                    GameObject pieceObject = Instantiate(piecePrefab, transform);
                    PieceController pieceController = pieceObject.GetComponent<PieceController>();

                    pieceController.Piece = piece;
                    PieceGUIControllers.Add(piece, pieceController);
                }
                
                PieceGUIControllers[piece].UpdateGUI(size);
            }
        }

        private float GetCellSize()
        {
            RectTransform rectTransform = transform as RectTransform;
            if (rectTransform == null)
            {
                //TODO: throw exception?
                return 0;
            }

            Rect rect = rectTransform.rect;
            float size = rect.size.x < rect.size.y ? rect.size.x : rect.size.y;
            size /= Board.Size;
            return size;
        }
    }
}
