using System;

namespace PacMan
{
    public record ConsoleKeyPressedEvent(ConsoleKey ConsoleKey) : IEvent;
}
