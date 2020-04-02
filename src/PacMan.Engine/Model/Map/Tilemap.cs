using System.Collections.Generic;
using System.Linq;

namespace PacMan
{
    public class Tilemap : ITilemap
    {
        private readonly Tile[,] _grid;

        public Tilemap(Size size)
        {
            _grid = new Tile[size.Height, size.Width];
            Size = size;
        }

        public Tile this[int row, int column]
        {
            get { return _grid[row, column]; }
            set { _grid[row, column] = value; }
        }

        public Size Size { get; }

        public ICollection<ISprite> All { get; } = new List<ISprite>();

        public IPacMan PacMan => All.OfType<IPacMan>().Single();

        public IEnumerable<IGhost> Ghosts => All.OfType<IGhost>();
    }
}
