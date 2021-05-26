using System;
using UnityEngine;
using UnityEngine.Events;

namespace Chess.CustomEvent
{
    public class EventListener : MonoBehaviour
    {
        public Event Event;
        public UnityEvent Response;
        
        public void OnEnable()
        {
            Event.RegisterListener(this);
        }
        
        public void OnDisable()
        {
            Event.UnregisterListener(this);
        }
        
        public void OnEventRaise()
        {
            Response.Invoke();
        }
    }
}
