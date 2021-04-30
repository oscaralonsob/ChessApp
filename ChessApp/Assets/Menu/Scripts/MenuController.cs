using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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
            
            CreateButton("New Game", 0, NewGame);
            CreateButton("Exit", 1, ExitGame);
        }

        private void CreateCell(int i, int j)
        {
            GameObject newCell = new GameObject();
            newCell.transform.parent = transform;
                    
            RectTransform rectTransform = newCell.AddComponent<RectTransform>();
            Image Image = newCell.AddComponent<Image>();
                    
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
            Image.color = blackCell ?  new Color32(128, 128, 128, 255) : new Color32(230, 230, 230, 255);

        }
        
        //TODO: create a class for buttons
        private void CreateButton(string t, int order, Action func)
        {
            // Create the cell
            GameObject newButton = Instantiate(buttonPrefab, transform);
            RectTransform rectTransform = newButton.GetComponent<RectTransform>();
            
            // Set position
            rectTransform.sizeDelta = new Vector2((3 - order) * CellSize, CellSize);
            rectTransform.anchoredPosition = new Vector2(0, ParentSize.y - (3 + order) * CellSize);
            
            // Set text
            TextMeshProUGUI text = newButton.GetComponentInChildren<TextMeshProUGUI>();
            text.text = t;
            
            // Set Action
            Button button = newButton.GetComponent<Button>();
            button.onClick.AddListener(delegate { func(); });
        }

        private void NewGame()
        {
            SceneManager.LoadScene("BoardScene");
        }
        
        private void ExitGame()
        {
            Application.Quit();
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
            int xCount = 0;
            int yCount = 0;
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
    }
}
