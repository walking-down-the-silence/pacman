using System;

namespace PacMan
{
    public class MovementHandler : IHandler<ConsoleKeyPressedEvent>
    {
        private readonly GameState _state;

        public MovementHandler(GameState state)
        {
            _state = state;
        }

        public void Handle(ConsoleKeyPressedEvent value)
        {
            switch (value.ConsoleKey)
            {
                case ConsoleKey.RightArrow:
                    _state.PacManNextTurn = Direction.Right;
                    break;
                case ConsoleKey.LeftArrow:
                    _state.PacManNextTurn = Direction.Left;
                    break;
                case ConsoleKey.UpArrow:
                    _state.PacManNextTurn = Direction.Up;
                    break;
                case ConsoleKey.DownArrow:
                    _state.PacManNextTurn = Direction.Down;
                    break;
                default:
                    _state.PacManNextTurn = Direction.None;
                    break;
            }
        }
    }
}
