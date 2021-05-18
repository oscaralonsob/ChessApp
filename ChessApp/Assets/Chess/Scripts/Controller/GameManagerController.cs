using Chess.Match;
using Chess.Match.Moves;
using Chess.MatchMode;
using CustomEvent;
using UnityEngine;

namespace Chess.Controller
{
    public class GameManagerController : MonoBehaviour, IGUIController
    {
        private NormalGameMode GameMode { set; get; }
        
        private MatchManager MatchManager { set; get; }

        private BoardController BoardController { get; set; }

        private GameEventListener<Move> EventListener { get; set; }

        [SerializeField] private GameObject boardPrefab;

        [SerializeField] private GameEvent<Move> gameEvent;

        void Start()
        {
            GameMode = new NormalGameMode();
            MatchManager = new MatchManager(GameMode);
            EventListener = new GameEventListener<Move>(gameEvent);

            EventListener.Handler += MovementDoneHandler;

            UpdateGUI();
        }
        public void UpdateGUI(float size = 0)
        {
            GameObject boardObject = Instantiate(boardPrefab, transform);
            BoardController = boardObject.GetComponent<BoardController>();
            
            BoardController.Board = MatchManager.Board;
            BoardController.Init();
        }

        private void MovementDoneHandler(object sender, Move move)
        {
            MatchManager.ApplyMove(move);
            //menu if is over
            BoardController.UpdateGUI();
        }
    }
}
