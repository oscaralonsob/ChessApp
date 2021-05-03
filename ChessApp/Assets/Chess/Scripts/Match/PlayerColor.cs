namespace Chess.Match
{
    public enum PlayerColor
    {
        White, 
        Black 
    }
   
    public static class PlayerColorExtension 
    {
        public static PlayerColor GetNextPlayerColor(this PlayerColor playerColor)
        {
            return playerColor == PlayerColor.White
                ? PlayerColor.Black
                : PlayerColor.White;
        }
    }

}