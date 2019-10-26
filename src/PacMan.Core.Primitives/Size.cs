namespace PacMan
{
    public sealed class Size
    {
        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public static Size Empty => new Size(0, 0);

        public int Width { get; }

        public int Height { get; }

        public Size Resize(int extendWidth, int extendHeight)
        {
            return new Size(Width + extendWidth, Height + extendHeight);
        }
    }
}
