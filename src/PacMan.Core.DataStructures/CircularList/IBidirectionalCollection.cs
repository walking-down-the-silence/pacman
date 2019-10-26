using System.Collections.Generic;

namespace PacMan
{
    public interface IBidirectionalCollection<T> : ICollection<T>
    {
        T Current { get; }

        T Next();

        T Previous();
    }
}
