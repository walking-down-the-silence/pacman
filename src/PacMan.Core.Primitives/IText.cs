namespace PacMan
{
    public interface IText
    {
        char this[int index] { get; }

        string Text { get; }

        int Length { get; }

        Offset Position { get; }

        Color Forecolor { get; }
    }
}
