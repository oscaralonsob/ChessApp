using System.Linq;
using Chess.Match.AI;
using Chess.Match.Moves;
using Chess.MatchMode;
using Chess.CustomEvent;

namespace Chess.Match
{
    public class MatchManager
    {
        private PlayerColor ColorTurn { get; set; }

        public Board Board { get; }
        
        private IGameMode GameMode { get; }
        
        public GameOverEvent GameOverEvent { get; set; }
        
        public MatchManager(IGameMode gameMode)
        {
            ColorTurn = PlayerColor.White; 
            Board = new Board();
            GameMode = gameMode;

            Init();
        }

        private void Init()
        {
            Board.SetPieces(GameMode.PiecePlacement);
            UpdatePieceMovement();
            CheckGameOverCondition();
        }

        public void ApplyMove(Move move)
        {
            move.Apply(Board);
            SwitchTurn();
            UpdatePieceMovement();
            CheckGameOverCondition();
        }

        private void SwitchTurn()
        {
            ColorTurn = ColorTurn.GetNextPlayerColor();
        }
        
        private void UpdatePieceMovement()
        {
            GameMode.AttackMapGenerator.Generate(Board);
            GameMode.MoveGenerator.Generate(Board, ColorTurn);
        }
        
        private void CheckGameOverCondition()
        {
            bool hasMoves = Board.Pieces.Any(p => p.Color == ColorTurn && p.Moves.Count != 0);
            if (!hasMoves)
            {
                if (Board.GetKing(ColorTurn).Pin != null)
                {
                    GameOverEvent.Raise(ColorTurn.GetNextPlayerColor());
                }
                else
                {
                    GameOverEvent.Raise(null);
                }
            }
        }
    }
}


