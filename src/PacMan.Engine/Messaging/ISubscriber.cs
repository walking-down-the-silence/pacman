using System;

namespace PacMan
{
    public interface ISubscriber
    {
        void Subscribe<TEvent>(Action<TEvent> action);

        void Unsubscribe<TEvent>(Action<TEvent> action);
    }
}
