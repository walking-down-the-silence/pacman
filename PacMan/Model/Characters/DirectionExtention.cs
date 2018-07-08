using System;

namespace PacMan
{
    public static class DirectionExtention
    {
        public static Direction ToOpposite(this Direction direction)
        {
            switch (direction)
            {
                case Direction.None:
                    return Direction.None;
                case Direction.Left:
                    return Direction.Right;
                case Direction.LeftUp:
                    return Direction.RightDown;
                case Direction.Up:
                    return Direction.Down;
                case Direction.UpRight:
                    return Direction.DownLeft;
                case Direction.Right:
                    return Direction.Left;
                case Direction.RightDown:
                    return Direction.LeftUp;
                case Direction.Down:
                    return Direction.Up;
                case Direction.DownLeft:
                    return Direction.UpRight;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, string.Empty);
            }
        }

        public static Offset ToOffset(this Direction direction)
        {
            switch (direction)
            {
                case Direction.None:
                    return new Offset(0, 0);
                case Direction.Left:
                    return new Offset(-1, 0);
                case Direction.LeftUp:
                    return new Offset(-1, -1);
                case Direction.Up:
                    return new Offset(0, -1);
                case Direction.UpRight:
                    return new Offset(1, -1);
                case Direction.Right:
                    return new Offset(1, 0);
                case Direction.RightDown:
                    return new Offset(1, 1);
                case Direction.Down:
                    return new Offset(0, 1);
                case Direction.DownLeft:
                    return new Offset(-1, 1);
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, string.Empty);
            }
        }

        public static Offset Distance(this Direction direction, int speedPerSecond, DateTime lastTime, DateTime currentTime)
        {
            var shiftPerSecond = direction.ToOffset().Extend(speedPerSecond);
            var shiftOverTime = shiftPerSecond.Extend(lastTime, currentTime);
            return shiftOverTime;
        }
    }
}
