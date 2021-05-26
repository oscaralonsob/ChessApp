using System;
using System.Collections.Generic;
using Chess.Match;
using Chess.Match.Pieces;
using UnityEngine;
using Chess.CustomEvent;

namespace Chess.Controller
{
    public class BoardController : MonoBehaviour
    {
        public Board Board { get; set; }
        
        public GameObject cellPrefab;
        
        public GameObject piecePrefab;
        
        [SerializeField] private FloatReference sizeBoardReference;

        public void Start()
        {
            GetCellSize();
        }

        public void Init()
        {
            CreateCells();
            CreatePieces();
        }

        private void CreateCells()
        {
            foreach (Cell cell in Board.Cells)
            {
                GameObject newCell = Instantiate(cellPrefab, transform);
            
                CellController cellController = newCell.GetComponent<CellController>();
                cellController.Cell = cell;
            }
        }

        private void CreatePieces()
        {
            List<Piece> allPieces = new List<Piece>();
            
            allPieces.AddRange(Board.Pieces);
            allPieces.AddRange(Board.CapturedPieces);
            
            foreach (Piece piece in allPieces)
            {
                GameObject pieceObject = Instantiate(piecePrefab, transform);
                PieceController pieceController = pieceObject.GetComponent<PieceController>();

                pieceController.Piece = piece;
            }
        }

        private void GetCellSize()
        {
            sizeBoardReference.value = 0;
            RectTransform rectTransform = transform as RectTransform;
            if (rectTransform is { })
            {
                Rect rect = rectTransform.rect;
                float size = rect.size.x < rect.size.y ? rect.size.x : rect.size.y;
                size /= Board.Size;
                sizeBoardReference.value = size;
            }
        }
    }
}
