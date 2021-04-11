using Chess.Pieces;
using UnityEngine;

namespace Controller
{
    public class PieceController : MonoBehaviour
    {
        public Piece Piece { get; set; }

        public void Print()
        {
            RectTransform rectTransform = GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2((Piece.CurrentCell.X * 100) + 50, (Piece.CurrentCell.Y * 100) + 50);
        }
    }
}
