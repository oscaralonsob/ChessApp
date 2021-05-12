using System;
using Chess.Match;
using UnityEngine;
using Image = UnityEngine.UI.Image;

namespace Controller
{
    public class CellController : MonoBehaviour, IGUIController
    {
        public Cell Cell { get; set; }
        
        private RectTransform RectTransform { get; set; }

        private Transform HighlightImage { get; set; }
        
        private Image Image { get; set; }

        private void Awake()
        {
            RectTransform = GetComponent<RectTransform>();
            Image = GetComponent<Image>();
            HighlightImage = transform.GetChild(0);
        }
        
        private void Update()
        {
            HighlightImage.gameObject.SetActive(Cell.IsHighlighted);
        }

        public void UpdateGUI(float size)
        {
            // Set position
            RectTransform.sizeDelta = new Vector2(size, size);
            RectTransform.anchoredPosition = new Vector2(Cell.Position.X * size, Cell.Position.Y * size);
            
            // Set Color
            bool blackCell = (Cell.Position.Y + Cell.Position.X) % 2 == 0;
            Image.color = blackCell ?  new Color32(128, 128, 128, 255) : new Color32(230, 230, 230, 255);
        }
    }
}
