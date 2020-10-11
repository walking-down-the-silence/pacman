using System;
using System.Collections.Generic;

namespace PacMan
{
    public class EventSink : IEventSink
    {
        private readonly Dictionary<Type, List<object>> _subscribers = new ();

        public void Publish<TEvent>(TEvent value)
        {
            if (_subscribers.ContainsKey(value.GetType()))
            {
                void handler(object action) => (action as Action<TEvent>)?.Invoke(value);
                _subscribers[value.GetType()].ForEach(handler);
            }
        }

        public void Subscribe<TEvent>(Action<TEvent> action)
        {
            if (!_subscribers.ContainsKey(typeof(TEvent)))
            {
                _subscribers.Add(typeof(TEvent), new List<object>());
            }

            _subscribers[typeof(TEvent)].Add(action);
        }

        public void Unsubscribe<TEvent>(Action<TEvent> action)
        {
            if (!_subscribers.ContainsKey(typeof(TEvent)))
            {
                _subscribers.Remove(typeof(TEvent));
            }
        }
    }
}
