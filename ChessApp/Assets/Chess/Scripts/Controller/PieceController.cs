using System;
using Chess.Match.Moves;
using Chess.Match.Pieces;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Controller
{
    public class PieceController : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        public Piece Piece { get; set; }

        private bool IsDragging { get; set; }
        
        private RectTransform RectTransform { get; set; }
        
        private Image ImageComponent { get; set; }

        private void Awake()
        {
            RectTransform = GetComponent<RectTransform>();
            ImageComponent = GetComponent<Image>();
        }

        public void Print(float size)
        {
            ImageComponent.sprite = GetSprite();
            RectTransform.sizeDelta = new Vector2(size, size);
            
            if (IsDragging) return;
            RectTransform.anchoredPosition = new Vector2(Piece.Position.X * size, Piece.Position.Y * size);
        }

        public void Update()
        {
            Print(RectTransform.sizeDelta.x);
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
            transform.position += (Vector3)eventData.delta;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            foreach (Move move in Piece.Moves)
            {
                move.TargetCell.IsHighlighted = true;
            }
            IsDragging = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Move moveDone = null;

            foreach (Move move in Piece.Moves)
            {
                RectTransform rect = move.TargetCell.CellController.GetComponent<RectTransform>();
                if (RectTransformUtility.RectangleContainsScreenPoint(rect, Input.mousePosition))
                {
                    // If the mouse is within a valid cell, get it
                    moveDone = move;
                }

                move.TargetCell.IsHighlighted = false;
            }

            moveDone?.Apply();

            IsDragging = false;
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
