using UnityEngine;
using UnityEngine.UI;

public class CellController : MonoBehaviour
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public void Setup(int x, int y)
    {
        // Store info
        X = x;
        Y = y;
        
        // Set position
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2((X * 100) + 50, (Y * 100) + 50);
        
        // Set Color
        bool blackCell = (y + x) % 2 == 0;

        // Color
        GetComponent<Image>().color = blackCell ?  new Color32(128, 128, 128, 255) : new Color32(230, 230, 230, 255);
    }
}
