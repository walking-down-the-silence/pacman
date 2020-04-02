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

                for (int row = 0; row < source.Size.Height; row++)
                {
                    for (int column = 0; column < source.Size.Width; column++)
                    {
                        if (source[row, column] != Color.None && source[row, column] != Color.Transparent)
                        {
                            Console.BackgroundColor = source[row, column].ToConsoleColor();
                            int xPosition = (source.Position.Left + column) * emptyCell.Length;
                            int yPosition = source.Position.Top + row;
                            ConsoleExtentions.WriteAtPosition(xPosition, yPosition, emptyCell);
                        }
                    }
                }

                Console.ResetColor();
            }
        }
    }
}