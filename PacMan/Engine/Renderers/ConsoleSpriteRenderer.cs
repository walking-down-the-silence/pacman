using System;

namespace PacMan
{
    public sealed class ConsoleSpriteRenderer : ISpriteRenderer
    {
        public ConsoleSpriteRenderer()
        {
            Console.CursorVisible = false;
            Console.Clear();
        }

        public void Render(ISprite source)
        {
            if (source != null)
            {
                const string emptyCell = "  ";
                Console.ResetColor();
                Console.CursorVisible = false;

                for (int y = 0; y < source.Size.Height; y++)
                {
                    for (int x = 0; x < source.Size.Width; x++)
                    {
                        if (source[y, x] != Color.None && source[y, x] != Color.Transparent)
                        {
                            Console.BackgroundColor = source[y, x].ToConsoleColor();
                            int xPosition = (source.Position.Left + x) * emptyCell.Length;
                            int yPosition = source.Position.Top + y;
                            ConsoleExtentions.WriteAtPosition(xPosition, yPosition, emptyCell);
                        }
                    }
                }

                Console.ResetColor();
            }
        }
    }
}