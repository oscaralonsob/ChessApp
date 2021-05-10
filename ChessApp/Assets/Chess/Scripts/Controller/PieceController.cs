using System;
using Chess.Match.Moves;
using Chess.Match.Pieces;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;
using System.Collections.Generic;
using Image = UnityEngine.UI.Image;

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
            //Remove the high
            foreach (Move move in Piece.Moves)
            {
                move.TargetCell.IsHighlighted = false;
            }  
            
            //Create a list of Raycast Results
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);
            CellController cellController = null;
            foreach (var result in results.Where(result => result.gameObject.CompareTag("Cell")))
            {
                cellController = result.gameObject.GetComponent<CellController>();
            }

            if (cellController != null)
            {
                Move moveDone = null;
                
                foreach (var move in Piece.Moves.Where(move => cellController.Cell == move.TargetCell))
                {
                    moveDone = move;
                }
                
                moveDone?.Apply();
            }

            IsDragging = false;
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
