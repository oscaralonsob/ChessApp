using System;
using Menu.Buttons;
using UnityEngine;
using UnityEngine.SceneManagement;
using Image = UnityEngine.UI.Image;

namespace Menu
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField]
        private GameObject buttonPrefab;
        private float CellSize { get; set; }
        
        private Vector2 CellCount { get; set; } 
        
        private Vector2 ParentSize { get; set; } 

        private void Start()
        {
            CreateBackGround();
        }

        private void CreateBackGround()
        {
            Setup();

            for (int i = 0; i < CellCount.x; i++)
            {
                for (int j = 0; j < CellCount.y; j++)
                {
                    CreateCell(i, j);
                }
            }

            CreateButton(3, 3, "New Game", LoadLevel);
            CreateButton(4, 3, "Credits", LoadCredits);
            CreateButton(5, 2, "Exit", Exit);
        }

        private void CreateCell(int i, int j)
        {
            GameObject newCell = new GameObject();
            newCell.transform.parent = transform;
                    
            RectTransform rectTransform = newCell.AddComponent<RectTransform>();
            Image image = newCell.AddComponent<Image>();
                    
            // Default values
            rectTransform.anchorMax = new Vector2(0, 0);
            rectTransform.anchorMin = new Vector2(0, 0);
            rectTransform.pivot = new Vector2(0, 0);
            rectTransform.localScale = new Vector2(1, 1);
                    
            // Set position
            rectTransform.sizeDelta = new Vector2(CellSize, CellSize);
            rectTransform.anchoredPosition = new Vector2(i * CellSize, ParentSize.y - j * CellSize - CellSize);

        
            // Set Color
            bool blackCell = (i + j) % 2 == 0;

            // Color
            image.color = blackCell ?  new Color32(128, 128, 128, 255) : new Color32(230, 230, 230, 255);

        }
        
        private void CreateButton(int cellStart, int cells, string text, Action action)
        {
            Vector2 size = new Vector2(cells * CellSize, CellSize);
            Vector2 position = new Vector2(0, ParentSize.y - cellStart * CellSize);
            MenuButton menuButton = new MenuButton(text, size, position, action);
            
            GameObject newButton = Instantiate(buttonPrefab, transform);
            ButtonController buttonController = newButton.GetComponent<ButtonController>();
            
            buttonController.Setup(CellSize, ParentSize.y, menuButton);
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
            ParentSize = rect.size;
            if (ParentSize.x < ParentSize.y)
            {
                xCount = 8;
                CellSize = ParentSize.x / xCount;
                yCount = (int) Math.Ceiling(ParentSize.y / CellSize);
            }
            else
            {
                yCount = 8;
                CellSize = ParentSize.y / yCount;
                xCount = (int) Math.Ceiling(ParentSize.x / CellSize);
            }
            
            CellCount = new Vector2(xCount, yCount);
        }
        
        private void LoadLevel()
        {
            SceneManager.LoadScene("BoardScene");
        }
        
        private void LoadCredits()
        {
            SceneManager.LoadScene("BoardScene");
        }
        
        private void Exit()
        {
            Application.Quit();
        }
    }
}
