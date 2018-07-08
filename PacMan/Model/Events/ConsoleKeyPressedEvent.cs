using System;

namespace PacMan
{
    public class ConsoleKeyPressedEvent : Event
    {
        public ConsoleKeyPressedEvent(ConsoleKey consoleKey)
        {
            ConsoleKey = consoleKey;
        }

        public ConsoleKey ConsoleKey { get; }
    }
}
