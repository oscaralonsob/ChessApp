using Chess.GameMode;
using Chess.Pieces;
using UnityEngine;

namespace Controller
{
    public class GameManagerController : MonoBehaviour
    {
        private NormalGameMode GameMode { set; get; }
        private GameModeManager GameModeManager { set; get; }
        
        public GameObject boardPrefab;
        
        public GameObject piecePrefab;
        
        
        // Start is called before the first frame update
        void Start()
        {
            GameMode = new NormalGameMode();
            GameModeManager = new GameModeManager(GameMode);
            
            GameModeManager.Setup();

            Print();
        }

        private void Print()
        {
            GameObject boardObject = Instantiate(boardPrefab, transform);
            BoardController boardController = boardObject.GetComponent<BoardController>();

            boardController.Board = GameModeManager.Board;
            boardController.Print();

            foreach (Piece piece in GameModeManager.Pieces)
            {
                GameObject pieceObject = Instantiate(piecePrefab, boardObject.transform);
                PieceController pieceController = pieceObject.GetComponent<PieceController>();

                pieceController.Piece = piece;
                pieceController.Print();
            }

        }
    }
}
