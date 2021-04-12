using System.Collections.Generic;
using Chess;
using Chess.Pieces;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Controller
{
    public class PieceController : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        public Piece Piece { get; set; }

        public void Print()
        {
            RectTransform rectTransform = GetComponent<RectTransform>();
            Image img = GetComponent<Image>();

            img.sprite = GetSprite();
            rectTransform.anchoredPosition = new Vector2((Piece.CurrentCell.X * 100) + 50, (Piece.CurrentCell.Y * 100) + 50);
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

        public void OnBeginDrag(PointerEventData eventData)
        {
            List<Cell> allowedCells = Piece.Movement();

            foreach (Cell allowedCell in allowedCells)
            {
                allowedCell.HighlightCell();
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position += (Vector3)eventData.delta;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            
        }
    }
}
