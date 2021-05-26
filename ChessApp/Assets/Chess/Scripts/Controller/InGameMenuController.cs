using Chess.Match;
using Chess.CustomEvent;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Chess.Controller
{
    public class InGameMenuController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI gameOverTextMeshPro;

        public void GameOverHandler(PlayerColor? move)
        {
            transform.GetChild(0).gameObject.SetActive(true);

            gameOverTextMeshPro.text = move == null ? "Draw" : move.Value + " Wins";
        }

        public void LoadLevel()
        {
            SceneManager.LoadScene("BoardScene");
        }
        
        public void Exit()
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
}
