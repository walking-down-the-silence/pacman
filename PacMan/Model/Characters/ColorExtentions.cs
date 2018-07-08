using System;

namespace PacMan
{
    public static class ColorExtentions
    {
        public static void RenderBitmap(this Color[,] bitmap, ISprite sprite)
        {
            int viewHeight = bitmap.GetLength(0);
            int viewWidth = bitmap.GetLength(1);

            for (int y = 0; y < sprite.Size.Height; y++)
            {
                for (int x = 0; x < sprite.Size.Width; x++)
                {
                    int col = sprite.Position.Left + x;
                    int row = sprite.Position.Top + y;

                    if (col >= 0
                        && col < viewWidth
                        && row >= 0
                        && row < viewHeight
                        && sprite[y, x] != Color.None
                        && sprite[y, x] != Color.Transparent)
                    {
                        bitmap[row, col] = sprite[y, x];
                    }
                }
            }
        }

        public static Color[,] ToBitmap(this Color color, bool[,] cells)
        {
            int height = cells.GetLength(0);
            int width = cells.GetLength(1);
            Color[,] colors = new Color[height, width];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    colors[i, j] = cells[i, j] ? color : Color.None;
                }
            }

            return colors;
        }

        public static ConsoleColor ToConsoleColor(this Color color)
        {
            switch (color)
            {
                case Color.Black:
                    return ConsoleColor.Black;
                case Color.White:
                    return ConsoleColor.White;
                case Color.Gray:
                    return ConsoleColor.Gray;
                case Color.DarkGreen:
                    return ConsoleColor.DarkGreen;
                case Color.Green:
                case Color.LightGreen:
                    return ConsoleColor.Green;
                case Color.DarkBlue:
                    return ConsoleColor.DarkBlue;
                case Color.Blue:
                case Color.LightBlue:
                    return ConsoleColor.Blue;
                case Color.DarkRed:
                    return ConsoleColor.DarkRed;
                case Color.Red:
                case Color.LightRed:
                    return ConsoleColor.Red;
                case Color.DarkYellow:
                    return ConsoleColor.DarkYellow;
                case Color.Yellow:
                case Color.LightYellow:
                    return ConsoleColor.Yellow;
                case Color.DarkCyan:
                    return ConsoleColor.DarkCyan;
                case Color.Cyan:
                case Color.LightCyan:
                    return ConsoleColor.Cyan;
                case Color.DarkPink:
                    return ConsoleColor.DarkMagenta;
                case Color.Pink:
                case Color.LightPink:
                    return ConsoleColor.Magenta;
                default:
                    throw new ArgumentOutOfRangeException(nameof(color), color, string.Empty);
            }
        }
    }
}