using Chess.Match.Moves;
using Chess.Match.Pieces;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;
using System.Collections.Generic;
using Chess.CustomEvent;
using Image = UnityEngine.UI.Image;

namespace Chess.Controller
{
    public class PieceController : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler, IGUIController
    {
        public Piece Piece { get; set; }
        
        private RectTransform RectTransform { get; set; }
        
        private Image ImageComponent { get; set; }

        [SerializeField] private MoveGameEvent selectedMovementEvent;

        private void Awake()
        {
            RectTransform = GetComponent<RectTransform>();
            ImageComponent = GetComponent<Image>();
        }
        
        public void UpdatedBoardHandler(FloatReference size)
        {
            //TODO: add in another place where the captures pieces will be displayed
            if (Piece.IsCaptured)
            {
                gameObject.SetActive(false);
            }
            
            RectTransform.sizeDelta = new Vector2(size.value, size.value);

            ImageComponent.sprite = GetSprite();
            RectTransform.anchoredPosition = new Vector2(Piece.Position.X * size.value, Piece.Position.Y * size.value);
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
        }

        public void OnPointerUp(PointerEventData eventData)
        {
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

            
            Move moveSelected = null;
            if (cellController != null)
            {
                foreach (var move in Piece.Moves.Where(move => cellController.Cell == move.TargetCell))
                {
                    moveSelected = move;
                }
            }

            if (moveSelected != null)
            {
                selectedMovementEvent.Raise(moveSelected);
            }
            else
            {
                float size = RectTransform.sizeDelta.x;
                RectTransform.anchoredPosition = new Vector2(Piece.Position.X * size, Piece.Position.Y * size);
            }
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
    }
}
