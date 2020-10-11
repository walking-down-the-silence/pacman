namespace PacMan
{
    public record AxisAlignedBoundingBox(Vector2D LeftBottom, Vector2D RightTop)
    {
        public static AxisAlignedBoundingBox Empty => new AxisAlignedBoundingBox(Vector2D.Zero, Vector2D.Zero);

        public int Volume => Size.X * Size.Y;

        public Vector2D Size => new Vector2D(RightTop.X - LeftBottom.X, RightTop.Y - LeftBottom.Y);
    }
}
