using static System.Math;
using System;

namespace PacMan
{
    public static partial class OffsetExtentions
    {
        public static double EuclideanDistance(this Offset source, Offset target)
        {
            return Sqrt(Pow(target.Left - source.Left, 2) + Pow(target.Top - source.Top, 2));
        }

        public static double ManhattanDistance(this Offset source, Offset target)
        {
            return Abs(source.Left - target.Left) + Abs(source.Top - target.Top);
        }

        public static Direction ToDirection(this Offset current, Offset target)
        {
            if (current == null || target == null)
            {
                return Direction.None;
            }

            int shiftX = target.Left - current.Left;
            int shiftY = target.Top - current.Top;
            var direction = (Sign(shiftX), Sign(shiftY));

            return direction switch
            {
                (0, 0)   => Direction.None,
                (-1, 0)  => Direction.Left,
                (-1, -1) => Direction.LeftUp,
                (0, -1)  => Direction.Up,
                (1, -1)  => Direction.UpRight,
                (1, 0)   => Direction.Right,
                (1, 1)   => Direction.RightDown,
                (0, 1)   => Direction.Down,
                (-1, 1)  => Direction.DownLeft,
                _        => throw new InvalidOperationException($"Cannot convert {nameof(current)} value to direction."),
            };
        }

        public static Offset Align(this Offset current, Offset target, Direction direction)
        {
            return direction switch
            {
                Direction.Left => new Offset(Max(current.Left, target.Left), Min(current.Top, target.Top)),
                Direction.Up => new Offset(Min(current.Left, target.Left), Max(current.Top, target.Top)),
                Direction.Right => new Offset(Min(current.Left, target.Left), Min(current.Top, target.Top)),
                Direction.Down => new Offset(Min(current.Left, target.Left), Min(current.Top, target.Top)),
                _ => current.Minimum(target),
            };
        }
    }
}
