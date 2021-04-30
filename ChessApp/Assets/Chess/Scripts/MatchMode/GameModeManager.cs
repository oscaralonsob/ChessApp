using Chess.Match;

namespace Chess.MatchMode
{
    public class GameModeManager
    {
        public Board Board { get; }

        public GameModeManager(IGameMode gameMode)
        {
            Board    = new Board();
            Board.SetPieces(gameMode.PiecePlacement());
        }
    }
}
