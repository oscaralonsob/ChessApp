using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Buttons
{
    public class ButtonController : MonoBehaviour
    {
        public void Setup(float size, float yPosition, MenuButton menuButton)
        {
            RectTransform rectTransform = GetComponent<RectTransform>();
            
            // Set position
            //rectTransform.sizeDelta = new Vector2((3 - menuButton.Order) * size, size);
            //rectTransform.anchoredPosition = new Vector2(0, yPosition - (3 + menuButton.Order) * size);
            rectTransform.sizeDelta = menuButton.Size;
            rectTransform.anchoredPosition = menuButton.Position;
            
            // Set text
            TextMeshProUGUI text = GetComponentInChildren<TextMeshProUGUI>();
            text.text = menuButton.Text;
            
            // Set Action
            Button button = GetComponent<Button>();
            button.onClick.AddListener(delegate { menuButton.Action(); });
        }
    }
}
