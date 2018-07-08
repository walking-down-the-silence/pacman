namespace PacMan
{
    public class ConsoleContext
    {
        public ConsoleContext(int fps, int offsetX, int offsetY)
        {
            Fps = fps;
            OffsetX = offsetX;
            OffsetY = offsetY;
        }

        public int Fps { get; }

        public int OffsetX { get; }

        public int OffsetY { get; }
    }
}
