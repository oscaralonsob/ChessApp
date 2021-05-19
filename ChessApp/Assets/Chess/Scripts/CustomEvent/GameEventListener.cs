using System;

namespace Chess.CustomEvent
{
    public class GameEventListener<T>
    {
        private GameEvent<T> GameEvent { get; set; }
        public EventHandler<T> Handler;

        public GameEventListener(GameEvent<T> gameEvent)
        {
            GameEvent = gameEvent;
            GameEvent.RegisterListener(this);
        }

        public void OnEventRaise(T argument)
        {
            Handler.Invoke(this, argument);
        }
    }
}
