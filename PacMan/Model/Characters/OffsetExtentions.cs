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

            switch (direction)
            {
                case ValueTuple<int, int> t when t == (0, 0):
                    return Direction.None;
                case ValueTuple<int, int> t when t == (-1, 0):
                    return Direction.Left;
                case ValueTuple<int, int> t when t == (-1, -1):
                    return Direction.LeftUp;
                case ValueTuple<int, int> t when t == (0, -1):
                    return Direction.Up;
                case ValueTuple<int, int> t when t == (1, -1):
                    return Direction.UpRight;
                case ValueTuple<int, int> t when t == (1, 0):
                    return Direction.Right;
                case ValueTuple<int, int> t when t == (1, 1):
                    return Direction.RightDown;
                case ValueTuple<int, int> t when t == (0, 1):
                    return Direction.Down;
                case ValueTuple<int, int> t when t == (-1, 1):
                    return Direction.DownLeft;
                default:
                    throw new InvalidOperationException($"Cannot convert {nameof(current)} value to direction.");
            }
        }

        public static Offset Align(this Offset current, Offset target, Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    return new Offset(Max(current.Left, target.Left), Min(current.Top, target.Top));
                case Direction.Up:
                    return new Offset(Min(current.Left, target.Left), Max(current.Top, target.Top));
                case Direction.Right:
                    return new Offset(Min(current.Left, target.Left), Min(current.Top, target.Top));
                case Direction.Down:
                    return new Offset(Min(current.Left, target.Left), Min(current.Top, target.Top));
                default:
                    return current.Minimum(target);
            }
        }

        public static Vertex ToVertex(this ISprite sprite)
        {
            return new Vertex(sprite.Position.Top / 7, sprite.Position.Left / 7, false);
        }

        public static Vertex ToVertex(this Offset offset)
        {
            return new Vertex(offset.Top / 7, offset.Left / 7, false);
        }
    }
}
