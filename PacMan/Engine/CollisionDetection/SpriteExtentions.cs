namespace PacMan
{
    public static class SpriteExtentions
    {
        public static AxisAlignedBoundingBox ToBoundingBox(this ISprite sprite)
        {
            var shifted = sprite.Position.Shift(sprite.Size.Width, sprite.Size.Height);
            var leftBottom = new Vector2D(sprite.Position.Left, sprite.Position.Top);
            var rightTop = new Vector2D(shifted.Left, shifted.Top);
            return new AxisAlignedBoundingBox(leftBottom, rightTop);
        }

        public static ISprite GetBitmapDifference(this ISprite previousView, ISprite currentView, Color backgroundColor)
        {
            int height = previousView.Size.Height;
            int width = previousView.Size.Width;
            Color[,] differenceView = new Color[height, width];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (previousView[y, x] == currentView[y, x])
                    {
                        differenceView[y, x] = Color.None;
                    }
                    else
                    {
                        differenceView[y, x] =
                            currentView[y, x] == Color.None
                            ? backgroundColor
                            : currentView[y, x];
                    }
                }
            }

            return new GenericSprite(Offset.Default, differenceView);
        }
    }
}
