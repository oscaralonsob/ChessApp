using System.Linq;
using Chess.Match.AI;
using Chess.Match.Moves;
using Chess.MatchMode;

namespace Chess.Match
{
    public class MatchManager
    {
        private PlayerColor ColorTurn { get; set; }
        
        private PlayerColor Winner { get; set; }

        private bool Draw { get; set; }

        public Board Board { get; }
        
        private IGameMode GameMode { get;  }
        
        public MatchManager(IGameMode gameMode)
        {
            ColorTurn = PlayerColor.White; 
            Board = new Board();
            GameMode = gameMode;

            Init();
        }

        private void Init()
        {
            Board.SetPieces(GameMode.PiecePlacement());
            UpdatePieceMovement();
            CheckGameOverCondition();
        }

        public void ApplyMove(Move move)
        {
            move.Apply();
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
            AttackMapGenerator amg = new AttackMapGenerator();
            amg.Generate(Board);
            
            MoveGenerator mg = new MoveGenerator();
            mg.Generate(Board, ColorTurn);
        }
        
        private void CheckGameOverCondition()
        {
            bool hasMoves = Board.Pieces.Any(p => p.Color == ColorTurn && p.Moves.Count != 0);
            if (!hasMoves)
            {
                if (Board.GetKing(ColorTurn).Pin != null)
                {
                    Winner = ColorTurn.GetNextPlayerColor();
                }
                else
                {
                    Draw = true;
                }
            }
        }
    }
}


