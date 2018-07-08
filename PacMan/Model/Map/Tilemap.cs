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
            All = new List<ISprite>();
        }

        public Tile this[int row, int column]
        {
            get { return _graph[row, column] as Tile; }
            set { _graph[row, column] = value; }
        }

        public Size Size { get; }

        public ICollection<ISprite> All { get; private set; }

        public IPacMan PacMan => All.OfType<IPacMan>().Single();

        public IReadOnlyCollection<IGhost> Ghosts => All.OfType<IGhost>().ToList();

        public IReadOnlyCollection<ICheckpoint> Checkpoints => All.OfType<ICheckpoint>().ToList();

        public IGraph AsGraph() => _graph;
    }
}
