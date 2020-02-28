using System.Collections.Generic;
using System.Linq;

namespace PacMan
{
    public class Tilemap : ITilemap
    {
        private readonly IGraph _graph;

        public Tilemap(Size size)
        {
            _graph = new AdjacentMatrixGraph(size.Height, size.Width);
            Size = size;
        }

        public Tile this[int row, int column]
        {
            get { return _graph[row, column] as Tile; }
            set { _graph[row, column] = value; }
        }

        public Size Size { get; }

        public ICollection<ISprite> All { get; } = new List<ISprite>();

        public IPacMan PacMan => All.OfType<IPacMan>().Single();

        public IEnumerable<IGhost> Ghosts => All.OfType<IGhost>();

        public IGraph AsGraph() => _graph;
    }
}
