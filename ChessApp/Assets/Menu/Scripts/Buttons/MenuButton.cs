using System;
using UnityEngine;

namespace Menu.Buttons
{
    public class MenuButton
    {
        public string Text { get; }

        public Vector2 Size { get; }
        
        public Vector2 Position { get; }
        
        public Action Action { get;  }

        public MenuButton(string text, Vector2 size, Vector2 position, Action action)
        {
            Text = text;
            Size = size;
            Position = position;
            Action = action;
        }
    }
}
