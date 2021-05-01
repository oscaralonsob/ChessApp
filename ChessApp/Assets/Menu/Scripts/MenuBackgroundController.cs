using System;
using UnityEngine;
using Image = UnityEngine.UI.Image;

namespace Menu
{
    public class MenuBackgroundController : MonoBehaviour
    {
        private float CellSize { get; set; }
        
        private Vector2 CellCount { get; set; }
        
        private Vector2 ScreenSize { get; set; }

        private void Start()
        {
            Setup();

            for (int i = 0; i < CellCount.x; i++)
            {
                for (int j = 0; j < CellCount.y; j++)
                {
                    CreateCell(i, j);
                }
            }
        }

        private void CreateCell(int i, int j)
        {
            GameObject newCell = new GameObject();
            newCell.transform.parent = transform;
            newCell.transform.SetSiblingIndex(0);
                    
            RectTransform rectTransform = newCell.AddComponent<RectTransform>();
            Image image = newCell.AddComponent<Image>();
                    
            // Default values
            rectTransform.anchorMax = new Vector2(0, 0);
            rectTransform.anchorMin = new Vector2(0, 0);
            rectTransform.pivot = new Vector2(0, 0);
            rectTransform.localScale = new Vector2(1, 1);
                    
            // Set position
            rectTransform.sizeDelta = new Vector2(CellSize, CellSize);
            rectTransform.anchoredPosition = new Vector2(i * CellSize, ScreenSize.y - j * CellSize - CellSize);

        
            // Set Color
            bool blackCell = (i + j) % 2 == 0;

            // Color
            image.color = blackCell ?  new Color32(128, 128, 128, 255) : new Color32(230, 230, 230, 255);

        }

        private void Setup()
        {
            RectTransform rectTransform = transform as RectTransform;
            if (rectTransform == null)
            {
                //TODO: throw exception?
                return;
            }
            
            //TODO: get correct value
            Rect rect = rectTransform.rect;
            int xCount;
            int yCount;
            ScreenSize = rect.size;
            if (ScreenSize.x < ScreenSize.y)
            {
                xCount = 8;
                CellSize = ScreenSize.x / xCount;
                yCount = (int) Math.Ceiling(ScreenSize.y / CellSize);
            }
            else
            {
                yCount = 8;
                CellSize = ScreenSize.y / yCount;
                xCount = (int) Math.Ceiling(ScreenSize.x / CellSize);
            }
            
            CellCount = new Vector2(xCount, yCount);
        }
    }
}
