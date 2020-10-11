namespace PacMan
{
    public sealed record Vector2D(int X, int Y)
    {
        public static Vector2D Zero => new Vector2D(0, 0);
    }
}
