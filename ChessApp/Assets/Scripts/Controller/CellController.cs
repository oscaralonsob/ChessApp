using Chess.Match;
using UnityEngine;
using Image = UnityEngine.UI.Image;

namespace Controller
{
    public class CellController : MonoBehaviour
    {
        public Cell Cell { get; set; }
        
        public Vector3 Position => gameObject.transform.position;

        public void HighlightCell()
        {
            Transform highlightImage = transform.GetChild(0);
            highlightImage.gameObject.SetActive(true);
        }
        
        public void ClearHighlightCell()
        {
            Transform highlightImage = transform.GetChild(0);
            highlightImage.gameObject.SetActive(false);
        }

        public void Print(float size)
        {
            // Set position
            RectTransform rectTransform = GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(size, size);
            rectTransform.anchoredPosition = new Vector2(Cell.Position.X * size, Cell.Position.Y * size);
        
            // Set Color
            bool blackCell = (Cell.Position.Y + Cell.Position.X) % 2 == 0;

            // Color
            GetComponent<Image>().color = blackCell ?  new Color32(128, 128, 128, 255) : new Color32(230, 230, 230, 255);
        }
        
        private void Update()
        {
            //TODO: just for testing
            
            bool blackCell = (Cell.Position.Y + Cell.Position.X) % 2 == 0;

            int red = Cell.IsUnderBlackAttack ? 128 : 0;
            int blue = Cell.IsUnderWhiteAttack ? 128 : 0;

            GetComponent<Image>().color = blackCell ?  new Color32((byte) (128 - red), 128, (byte) (128 - blue), 255) : new Color32((byte) (230 - red), 230, (byte) (230 - blue), 255);

        }
    }
}
