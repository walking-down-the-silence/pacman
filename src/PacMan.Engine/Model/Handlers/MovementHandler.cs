using System;

namespace PacMan
{
    public class MovementHandler : IHandler<ConsoleKeyPressedEvent>
    {
        private readonly GameState _state;

        public MovementHandler(GameState state)
        {
            _state = state ?? throw new ArgumentNullException(nameof(state));
        }

        public void Handle(ConsoleKeyPressedEvent value)
        {
            var direction = value.ConsoleKey switch
            {
                ConsoleKey.RightArrow => Direction.Right,
                ConsoleKey.LeftArrow => Direction.Left,
                ConsoleKey.UpArrow => Direction.Up,
                ConsoleKey.DownArrow => Direction.Down,
                _ => Direction.None,
            };
            _state.SetNextDirection(direction);
        }
    }
}
