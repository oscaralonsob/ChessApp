using System;
using UnityEngine;
using UnityEngine.Events;

namespace Chess.CustomEvent
{
    public class GenericEventListener<T> : MonoBehaviour
    {
        public GenericEvent<T> Event;
        public UnityEvent<T> Response;
        
        public void OnEnable()
        {
            Event.RegisterListener(this);
        }
        
        public void OnDisable()
        {
            Event.UnregisterListener(this);
        }
        
        public void OnEventRaise(T arg)
        {
            Response.Invoke(arg);
        }
    }
}
