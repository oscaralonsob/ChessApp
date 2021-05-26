using Chess.CustomEvent;
using Chess.Match;
using UnityEngine;
using Image = UnityEngine.UI.Image;

namespace Chess.Controller
{
    public class CellController : MonoBehaviour, IGUIController
    {
        public Cell Cell { get; set; }

        private void Update()
        {
            transform.GetChild(0).gameObject.SetActive(Cell.IsHighlighted);
        }

        public void UpdatedBoardHandler(FloatReference size)
        {
            RectTransform rectTransform = GetComponent<RectTransform>();
            Image image = GetComponent<Image>();
            
            // Set position
            rectTransform.sizeDelta = new Vector2(size.value, size.value);
            rectTransform.anchoredPosition = new Vector2(Cell.Position.X * size.value, Cell.Position.Y * size.value);
            
            // Set Color
            bool blackCell = (Cell.Position.Y + Cell.Position.X) % 2 == 0;
            image.color = blackCell ?  new Color32(128, 128, 128, 255) : new Color32(230, 230, 230, 255);
        }
    }
}
