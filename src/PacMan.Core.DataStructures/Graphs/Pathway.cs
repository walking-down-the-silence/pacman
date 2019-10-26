using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PacMan
{
    public class Pathway : IBidirectionalCollection<Vertex>
    {
        private readonly List<Vertex> _vertices;
        private int _currentIndex;

        public Pathway(IEnumerable<Vertex> vertices, long distance, AlgorithmState state)
        {
            _vertices = vertices.ToList();
            Distance = distance;
            State = state;
        }

        public long Distance { get; set; }

        public AlgorithmState State { get; }

        public Vertex Current => GetCurrent();

        public int Count => _vertices.Count;

        public bool IsReadOnly => false;

        public void Add(Vertex item) => _vertices.Add(item);

        public bool Remove(Vertex item) => _vertices.Remove(item);

        public void Clear() => _vertices.Clear();

        public bool Contains(Vertex item) => _vertices.Contains(item);

        public void CopyTo(Vertex[] array, int arrayIndex) => _vertices.CopyTo(array, arrayIndex);

        public IEnumerator<Vertex> GetEnumerator() => _vertices.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public Vertex Next()
        {
            _currentIndex = _currentIndex + 1;
            return GetCurrent();
        }

        public Vertex Previous()
        {
            _currentIndex = _currentIndex - 1;
            return GetCurrent();
        }

        private Vertex GetCurrent() => _currentIndex < _vertices.Count
            ? _vertices[_currentIndex] : default;
    }
}
