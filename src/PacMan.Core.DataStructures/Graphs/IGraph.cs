namespace PacMan
{
    public interface IGraph
    {
        Vertex this[int row, int column] { get; set; }

        int Width { get; }

        int Height { get; }
    }
}
