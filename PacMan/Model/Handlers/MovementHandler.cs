using System;

namespace PacMan
{
    public class MovementHandler : IHandler<ConsoleKeyPressedEvent>
    {
        private readonly PacManState _state;

        public MovementHandler(PacManState state)
        {
            _state = state;
        }

        public void Handle(ConsoleKeyPressedEvent value)
        {
            switch (value.ConsoleKey)
            {
                case ConsoleKey.RightArrow:
                    _state.Direction = Direction.Right;
                    break;
                case ConsoleKey.LeftArrow:
                    _state.Direction = Direction.Left;
                    break;
                case ConsoleKey.UpArrow:
                    _state.Direction = Direction.Up;
                    break;
                case ConsoleKey.DownArrow:
                    _state.Direction = Direction.Down;
                    break;
                default:
                    _state.Direction = Direction.None;
                    break;
            }
        }
    }
}
