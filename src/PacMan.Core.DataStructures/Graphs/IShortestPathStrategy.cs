namespace PacMan
{
    public interface IShortestPathStrategy
    {
        Pathway FindPath(IGraph graph, Vertex start, Vertex target);
    }
}
