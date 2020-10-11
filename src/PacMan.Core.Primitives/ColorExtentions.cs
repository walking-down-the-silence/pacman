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
            return color switch
            {
                Color.Black => ConsoleColor.Black,
                Color.White => ConsoleColor.White,
                Color.Gray => ConsoleColor.Gray,
                Color.DarkGreen => ConsoleColor.DarkGreen,
                Color.Green or Color.LightGreen => ConsoleColor.Green,
                Color.DarkBlue => ConsoleColor.DarkBlue,
                Color.Blue or Color.LightBlue => ConsoleColor.Blue,
                Color.DarkRed => ConsoleColor.DarkRed,
                Color.Red or Color.LightRed => ConsoleColor.Red,
                Color.DarkYellow => ConsoleColor.DarkYellow,
                Color.Yellow or Color.LightYellow => ConsoleColor.Yellow,
                Color.DarkCyan => ConsoleColor.DarkCyan,
                Color.Cyan or Color.LightCyan => ConsoleColor.Cyan,
                Color.DarkPink => ConsoleColor.DarkMagenta,
                Color.Pink or Color.LightPink => ConsoleColor.Magenta,
                _ => throw new ArgumentOutOfRangeException(nameof(color), color, string.Empty),
            };
        }
    }
}