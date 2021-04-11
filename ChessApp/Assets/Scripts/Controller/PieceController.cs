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
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

            spriteRenderer.sprite = GetSprite();
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
    }
}
