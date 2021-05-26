using System.Linq;
using Chess.Match.AI;
using Chess.Match.Moves;
using Chess.MatchMode;
using Chess.CustomEvent;

namespace Chess.Match
{
    public class MatchManager
    {
        public PlayerColor ColorTurn { get; private set; }

        public Board Board { get; }
        
        private IGameMode GameMode { get; }

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
        }

        public void ApplyMove(Move move)
        {
            move.Apply(Board);
            SwitchTurn();
            UpdatePieceMovement();
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

        public bool GameOver()
        {
            return !Board.Pieces.Any(p => p.Color == ColorTurn && p.Moves.Count != 0);
        }
        
        public bool IsDraw()
        {
            return GameOver() && Board.GetKing(ColorTurn).Pin == null;
        }
    }
}


