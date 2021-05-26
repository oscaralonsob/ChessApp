using Chess.CustomEvent;
using Chess.Match;
using Chess.Match.Moves;
using Chess.MatchMode;
using UnityEngine;
using Event = Chess.CustomEvent.Event;

namespace Chess.Controller
{
    public class GameManagerController : MonoBehaviour
    {
        private NormalGameMode GameMode { set; get; }
        
        private MatchManager MatchManager { set; get; }

        private BoardController BoardController { get; set; }

        [SerializeField] private GameObject boardPrefab;

        [SerializeField] private Event updatedBoardEvent;
        
        [SerializeField] private PlayerColorGameEvent gameOverEvent;

        void Start()
        {
            GameMode = new NormalGameMode();
            MatchManager = new MatchManager(GameMode) {/*GameOverEvent = gameOverEvent*/};

            Init();
        }
        
        private void Init()
        {
            GameObject boardObject = Instantiate(boardPrefab, transform.GetChild(0));
            BoardController = boardObject.GetComponent<BoardController>();
            
            BoardController.Board = MatchManager.Board;
            BoardController.Init();
            updatedBoardEvent.Raise();
        }

        public void MovementDoneHandler(Move move)
        {
            MatchManager.ApplyMove(move);
            updatedBoardEvent.Raise();
            if (MatchManager.GameOver())
            {
                if (MatchManager.IsDraw())
                {
                    gameOverEvent.Raise(null);
                }
                else
                {
                    gameOverEvent.Raise(MatchManager.ColorTurn.GetNextPlayerColor());
                }
            }
            
        }
    }
}
