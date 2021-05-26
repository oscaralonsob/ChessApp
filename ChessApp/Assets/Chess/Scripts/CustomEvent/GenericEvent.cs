using System.Collections.Generic;
using UnityEngine;


namespace Chess.CustomEvent
{
    
    [CreateAssetMenu]
    public abstract class GenericEvent<T> : ScriptableObject
    {
        private List<GenericEventListener<T>> listeners = new List<GenericEventListener<T>>();

        public void Raise(T arg)
        {
            for (int i = listeners.Count - 1; i >= 0; i--) {
                listeners[i].OnEventRaise(arg);
            }
        }

        public void RegisterListener(GenericEventListener<T> listener)
        {
            listeners.Add(listener);
        }
        
        public void UnregisterListener(GenericEventListener<T> listener)
        {
            listeners.Remove(listener);
        }
    }
}
