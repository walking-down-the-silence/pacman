namespace PacMan
{
    public interface IFrame
    {
        Color this[int y, int x] { get; }

        Size Size { get; }
    }
}
