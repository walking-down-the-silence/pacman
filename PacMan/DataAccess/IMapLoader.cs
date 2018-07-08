using System.Collections.Generic;

namespace PacMan
{
    public interface IMapLoader<T>
    {
        ICollection<T> Load(string path, string searchPattern);
    }
}
