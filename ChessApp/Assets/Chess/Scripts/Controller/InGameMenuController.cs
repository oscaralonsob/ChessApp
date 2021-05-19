using Chess.Match;
using Chess.CustomEvent;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Chess.Controller
{
    public class InGameMenuController : MonoBehaviour
    {
        private GameEventListener<PlayerColor?> EventListener { get; set; }
        
        [SerializeField] private GameOverEvent gameOverEvent;
        
        [SerializeField] private TextMeshProUGUI gameOverTextMeshPro;

        
        void Start()
        {
            EventListener = new GameEventListener<PlayerColor?>(gameOverEvent);

            EventListener.Handler += Enable;
        }

        private void Enable(object sender, PlayerColor? move)
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
