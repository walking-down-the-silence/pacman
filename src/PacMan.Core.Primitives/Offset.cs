using System;
using static System.Math;

namespace PacMan
{
    public sealed record Offset(int Left, int Top)
    {
        public static Offset Default => new (0, 0);

        public Offset Extend(int times) => new (Left * times, Top * times);

        public Offset Extend(float times) => new ((int)(Left * times), (int)(Top * times));

        public Offset Extend(double times) => new ((int)(Left * times), (int)(Top * times));

        public Offset Extend(DateTime last, DateTime now) => Extend((now - last).TotalSeconds);

        public Offset Shift(Offset offset) => new (Left + offset.Left, Top + offset.Top);

        public Offset Shift(int shiftLeft, int shiftTop) => new (Left + shiftLeft, Top + shiftTop);

        public Offset Subtract(Offset offset) => new (Left - offset.Left, Top - offset.Top);

        public Offset Minimum(Offset offset) => new (Min(Left, offset.Left), Min(Top, offset.Top));

        public Offset Maximum(Offset offset) => new (Max(Left, offset.Left), Max(Top, offset.Top));
    }
}
