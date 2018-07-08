using System;
using static System.Math;

namespace PacMan
{
    public sealed class Offset
    {
        public Offset(int left, int top)
        {
            Left = left;
            Top = top;
        }

        public static Offset Default => new Offset(0, 0);

        public int Left { get; }

        public int Top { get; }

        public static bool operator ==(Offset offset1, Offset offset2) => InternalEquals(offset1, offset2);

        public static bool operator !=(Offset offset1, Offset offset2) => !InternalEquals(offset1, offset2);

        public override bool Equals(object obj) => (obj is Offset other) && InternalEquals(this, other);

        public override int GetHashCode() => Left ^ Top;

        public override string ToString() => $"Left = {Left}, Top = {Top}";

        public Offset Extend(int times) => new Offset(Left * times, Top * times);

        public Offset Extend(float times) => new Offset((int)(Left * times), (int)(Top * times));

        public Offset Extend(double times) => new Offset((int)(Left * times), (int)(Top * times));

        public Offset Extend(DateTime last, DateTime now) => Extend((now - last).TotalSeconds);

        public Offset Shift(Offset offset) => new Offset(Left + offset.Left, Top + offset.Top);

        public Offset Shift(int shiftLeft, int shiftTop) => new Offset(Left + shiftLeft, Top + shiftTop);

        public Offset Subtract(Offset offset) => new Offset(Left - offset.Left, Top - offset.Top);

        public Offset Minimum(Offset offset) => new Offset(Min(Left, offset.Left), Min(Top, offset.Top));

        public Offset Maximum(Offset offset) => new Offset(Max(Left, offset.Left), Max(Top, offset.Top));

        private static bool InternalEquals(Offset offset1, Offset offset2)
        {
            return ReferenceEquals(offset1, offset2)
                || ((object)offset1 != null
                    && (object)offset2 != null
                    && offset1.Left == offset2.Left
                    && offset1.Top == offset2.Top);
        }
    }
}
