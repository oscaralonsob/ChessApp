using Chess.Match;
using Chess.Match.Pieces;
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
            transform.position += (Vector3)eventData.delta;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            foreach (Move move in Piece.Moves)
            {
                move.TargetCell.HighlightCell();
            }
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

                move.TargetCell.ClearHighlightCell();
            }

            if (moveDone != null)
            {
                transform.position = moveDone.TargetCell.CellController.Position;
                Piece.Move(moveDone);
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
