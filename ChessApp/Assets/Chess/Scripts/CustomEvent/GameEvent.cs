using System.Collections.Generic;
using Chess.Match.Moves;
using UnityEngine;


namespace CustomEvent
{
    
    [CreateAssetMenu]
    public class GameEvent<T> : ScriptableObject
    {
        private List<GameEventListener<T>> listeners = new List<GameEventListener<T>>();

        public void Raise(T argument)
        {
            for (int i = listeners.Count - 1; i >= 0; i--) {
                listeners[i].OnEventRaise(argument);
            }
        }

        public void RegisterListener(GameEventListener<T> listener)
        {
            listeners.Add(listener);
        }
        
        public void UnregisterListener(GameEventListener<T> listener)
        {
            listeners.Remove(listener);
        }
    }
}
