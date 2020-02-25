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
    }
}
