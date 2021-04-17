using System;
using Chess.Pieces;
using Controller;

namespace Chess
{
    public class MetaCell
    {
        public bool IsUnderBlackAttack { get; set; }
        public bool IsUnderWhiteAttack { get; set; }

        public MetaCell()
        {
            Reset();
        }

        public void Reset()
        {
            IsUnderBlackAttack = false;
            IsUnderWhiteAttack = false;
        }

        public void SetCellUnderAttack(PlayerColor color)
        {
            if (color == PlayerColor.Black)
            {
                IsUnderBlackAttack = true;
            } else
            {
                IsUnderWhiteAttack = true;
            }
        }
    }   
}
