namespace PacMan
{
    public class Vector2D
    {
        public Vector2D(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Vector2D Zero => new Vector2D(0, 0);

        public int X { get; }

        public int Y { get; }
    }
}
