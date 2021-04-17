using System;
using Chess.Pieces;
using Controller;

namespace Chess
{
    public class MetaCell
    {
        private bool IsUnderBlackAttack { get; set; }
        private bool IsUnderWhiteAttack { get; set; }

        public MetaCell()
        {
            Reset();
        }

        public void Reset()
        {
            IsUnderBlackAttack = false;
            IsUnderWhiteAttack = false;
        }

        public void SetUnderAttack(PlayerColor color)
        {
            if (color == PlayerColor.Black)
            {
                IsUnderBlackAttack = true;
            } else
            {
                IsUnderWhiteAttack = true;
            }
        }
        
        public bool GetUnderAttack(PlayerColor color)
        {
            return color == PlayerColor.White ? IsUnderBlackAttack : IsUnderWhiteAttack;
        }
    }   
}
