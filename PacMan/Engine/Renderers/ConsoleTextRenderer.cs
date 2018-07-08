using System;

namespace PacMan
{
    public sealed class ConsoleTextRenderer : ITextRenderer
    {
        public ConsoleTextRenderer()
        {
            Console.CursorVisible = false;
        }

        public void Render(IText source)
        {
            if (source != null && !string.IsNullOrWhiteSpace(source.Text))
            {
                Console.ResetColor();
                Console.CursorVisible = false;
                Console.ForegroundColor = source.Forecolor.ToConsoleColor();
                ConsoleExtentions.WriteAtPosition(source.Position.Left, source.Position.Top, source.Text);
                Console.ResetColor();
            }
        }
    }
}