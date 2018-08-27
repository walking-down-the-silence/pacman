using System.Collections.Generic;

namespace PacMan
{
    public interface ITilemap
    {
        Tile this[int row, int column] { get; set; }

        Size Size { get; }

        ICollection<ISprite> All { get; }

        IPacMan PacMan { get; }

        IEnumerable<IGhost> Ghosts { get; }

        IGraph AsGraph();
    }
}
