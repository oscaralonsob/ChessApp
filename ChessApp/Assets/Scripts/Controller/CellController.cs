using Chess;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

namespace Controller
{
    public class CellController : MonoBehaviour
    {
        public Cell Cell { get; set; }
        
        public Vector3 Position
        {
            get => gameObject.transform.position;
        }

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

        public void Print()
        {
            // Set position
            RectTransform rectTransform = GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2((Cell.Position.X * 100) + 50, (Cell.Position.Y * 100) + 50);
        
            // Set Color
            bool blackCell = (Cell.Position.Y + Cell.Position.X) % 2 == 0;

            // Color
            GetComponent<Image>().color = blackCell ?  new Color32(128, 128, 128, 255) : new Color32(230, 230, 230, 255);
        }
    }
}
