using System.Collections.Generic;
using System.Data.Common;
using Chess;
using Chess.Pieces;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Controller
{
    public class PieceController : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        public Piece Piece { get; set; }

        public void Print()
        {
            RectTransform rectTransform = GetComponent<RectTransform>();
            Image img = GetComponent<Image>();

            img.sprite = GetSprite();
            rectTransform.anchoredPosition = new Vector2((Piece.Position.X * 100) + 50, (Piece.Position.Y * 100) + 50);
        }

        private Sprite GetSprite()
        {
            Sprite[] sprites  = Resources.LoadAll<Sprite>("Sprites/ChessPieces");
            
            foreach (var s in sprites)
            {
                if (s.name == Piece.GetSpriteName())
                    return s;
            }

            return null;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!Piece.IsMyTurn()) 
                return;
            
            transform.position += (Vector3)eventData.delta;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!Piece.IsMyTurn()) 
                return;
            
            List<Cell> allowedCells = Piece.AllowedCells;

            foreach (Cell allowedCell in allowedCells)
            {
                allowedCell.HighlightCell();
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (!Piece.IsMyTurn()) 
                return;
            
            List<Cell> allowedCells = Piece.AllowedCells;
            
            CellController targetCell = null;

            foreach (Cell allowedCell in allowedCells)
            {
                RectTransform rect = allowedCell.CellController.GetComponent<RectTransform>();
                if (RectTransformUtility.RectangleContainsScreenPoint(rect, Input.mousePosition))
                {
                    // If the mouse is within a valid cell, get it, and break.
                    targetCell = allowedCell.CellController;
                }

                allowedCell.ClearHighlightCell();
            }

            if (targetCell != null)
            {
                transform.position = targetCell.Position;
                Piece.Move(targetCell.Cell);
            } else
            {
                transform.position = Piece.CurrentCell.CellController.Position;
            }
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
