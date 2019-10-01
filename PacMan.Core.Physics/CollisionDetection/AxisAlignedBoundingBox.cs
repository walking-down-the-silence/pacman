namespace PacMan
{
    public class AxisAlignedBoundingBox
    {
        public AxisAlignedBoundingBox(Vector2D leftBotom, Vector2D rightTop)
        {
            LeftBottom = leftBotom;
            RightTop = rightTop;
        }

        public Vector2D LeftBottom { get; }

        public Vector2D RightTop { get; }
    }
}
