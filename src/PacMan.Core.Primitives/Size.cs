namespace PacMan
{
    public sealed record Size(int Width, int Height)
    {
        public static Size Empty => new Size(0, 0);

        public Size Resize(int extendWidth, int extendHeight) => new (Width + extendWidth, Height + extendHeight);
    }
}
