using Chess.MatchMode;
using UnityEngine;

namespace Controller
{
    public class GameManagerController : MonoBehaviour
    {
        private NormalGameMode GameMode { set; get; }
        
        private GameModeManager GameModeManager { set; get; }
        
        public GameObject boardPrefab;


        void Start()
        {
            GameMode = new NormalGameMode();
            GameModeManager = new GameModeManager(GameMode);

            Print();
        }

        private void Print()
        {
            GameObject boardObject = Instantiate(boardPrefab, transform);
            BoardController boardController = boardObject.GetComponent<BoardController>();

            boardController.Board = GameModeManager.Board;
            boardController.Init();
        }
    }
}
