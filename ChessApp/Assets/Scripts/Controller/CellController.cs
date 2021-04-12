using System;
using Chess;
using UnityEngine;
using UnityEngine.UI;

namespace Controller
{
    public class CellController : MonoBehaviour
    {
        private Cell _cell;
        public Cell Cell
        {
            get => _cell;
            set { 
                _cell = value;
                _cell.HighlightCellEvent += HighlightCell;
            }
        }

        private void HighlightCell(object sender, EventArgs e)
        {
            Transform highlightImage = transform.GetChild(0);
            highlightImage.gameObject.SetActive(true);
        }

        public void Print()
        {
            // Set position
            RectTransform rectTransform = GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2((Cell.X * 100) + 50, (Cell.Y * 100) + 50);
        
            // Set Color
            bool blackCell = (Cell.Y + Cell.X) % 2 == 0;

            // Color
            GetComponent<Image>().color = blackCell ?  new Color32(128, 128, 128, 255) : new Color32(230, 230, 230, 255);
        }
    }
}
