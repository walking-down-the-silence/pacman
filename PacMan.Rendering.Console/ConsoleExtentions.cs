using System;

namespace PacMan
{
    public static class ConsoleExtentions
    {
        public static void WriteAtPosition(int x, int y, string cell)
        {
            if (IsInBounds(x, y))
            {
                Console.SetCursorPosition(x, y);
                Console.Write(cell);
            }
        }

        public static bool IsInBounds(int x, int y)
        {
            return x >= 0 && x < Console.WindowWidth && y >= 0 && y < Console.WindowHeight;
        }
    }
}