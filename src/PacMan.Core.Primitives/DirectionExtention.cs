using System;

namespace PacMan
{
    public static class DirectionExtention
    {
        public static Direction ToOpposite(this Direction direction)
        {
            return direction switch
            {
                Direction.None => Direction.None,
                Direction.Left => Direction.Right,
                Direction.LeftUp => Direction.RightDown,
                Direction.Up => Direction.Down,
                Direction.UpRight => Direction.DownLeft,
                Direction.Right => Direction.Left,
                Direction.RightDown => Direction.LeftUp,
                Direction.Down => Direction.Up,
                Direction.DownLeft => Direction.UpRight,
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, string.Empty),
            };
        }

        public static Offset ToOffset(this Direction direction)
        {
            return direction switch
            {
                Direction.None => new Offset(0, 0),
                Direction.Left => new Offset(-1, 0),
                Direction.LeftUp => new Offset(-1, -1),
                Direction.Up => new Offset(0, -1),
                Direction.UpRight => new Offset(1, -1),
                Direction.Right => new Offset(1, 0),
                Direction.RightDown => new Offset(1, 1),
                Direction.Down => new Offset(0, 1),
                Direction.DownLeft => new Offset(-1, 1),
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, string.Empty),
            };
        }

        public static Offset Distance(this Direction direction, int speedPerSecond, DateTime lastTime, DateTime currentTime)
        {
            var shiftPerSecond = direction.ToOffset().Extend(speedPerSecond);
            var shiftOverTime = shiftPerSecond.Extend(lastTime, currentTime);
            return shiftOverTime;
        }
    }
}
