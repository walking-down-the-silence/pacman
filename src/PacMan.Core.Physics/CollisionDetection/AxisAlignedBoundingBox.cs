using System;

namespace PacMan
{
    public class AxisAlignedBoundingBox
    {
        public AxisAlignedBoundingBox(Vector2D leftBotom, Vector2D rightTop)
        {
            LeftBottom = leftBotom;
            RightTop = rightTop;
            Size = new Vector2D(rightTop.X - leftBotom.X, rightTop.Y - leftBotom.Y);
            Volume = Size.X * Size.Y;
        }

        public static AxisAlignedBoundingBox Empty => new AxisAlignedBoundingBox(Vector2D.Zero, Vector2D.Zero);

        public Vector2D LeftBottom { get; }

        public Vector2D RightTop { get; }

        public int Volume { get; }

        public Vector2D Size { get; }

        public static AxisAlignedBoundingBox Combine(AxisAlignedBoundingBox first, AxisAlignedBoundingBox second)
        {
            if (first == null) throw new ArgumentNullException(nameof(first));
            if (second == null) throw new ArgumentNullException(nameof(second));

            int left = Math.Min(first.LeftBottom.X, second.LeftBottom.X);
            int bottom = Math.Min(first.LeftBottom.Y, second.LeftBottom.Y);
            int right = Math.Max(first.RightTop.X, second.RightTop.X);
            int top = Math.Max(first.RightTop.Y, second.RightTop.Y);
            return new AxisAlignedBoundingBox(new Vector2D(left, bottom), new Vector2D(right, top));
        }
    }
}
