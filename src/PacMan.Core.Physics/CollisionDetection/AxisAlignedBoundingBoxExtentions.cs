using System;

namespace PacMan
{
    public static class AxisAlignedBoundingBoxExtentions
    {
        public static AxisAlignedBoundingBox Combine(this AxisAlignedBoundingBox first, AxisAlignedBoundingBox second)
        {
            if (first == null) throw new ArgumentNullException(nameof(first));
            if (second == null) throw new ArgumentNullException(nameof(second));

            int left = Math.Min(first.LeftBottom.X, second.LeftBottom.X);
            int bottom = Math.Min(first.LeftBottom.Y, second.LeftBottom.Y);
            int right = Math.Max(first.RightTop.X, second.RightTop.X);
            int top = Math.Max(first.RightTop.Y, second.RightTop.Y);
            return new AxisAlignedBoundingBox(new Vector2D(left, bottom), new Vector2D(right, top));
        }

        public static bool Overlap(this AxisAlignedBoundingBox first, AxisAlignedBoundingBox second)
        {
            if (first == null) throw new ArgumentNullException(nameof(first));
            if (second == null) throw new ArgumentNullException(nameof(second));

            return first.LeftBottom.X < second.RightTop.X
                && first.RightTop.X > second.LeftBottom.X
                && first.LeftBottom.Y < second.RightTop.Y
                && first.RightTop.Y > second.LeftBottom.Y;
        }
    }
}
