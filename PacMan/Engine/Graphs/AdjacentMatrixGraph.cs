namespace PacMan
{
    public class AdjacentMatrixGraph : IGraph
    {
        private readonly Vertex[,] _grid;

        public AdjacentMatrixGraph(int height, int width)
        {
            _grid = new Vertex[height, width];
            Height = height;
            Width = width;
            InitializeGrid();
        }

        public Vertex this[int row, int column]
        {
            get { return _grid[row, column]; }
            set { _grid[row, column] = value; }
        }

        public int Width { get; private set; }

        public int Height { get; private set; }

        private void InitializeGrid()
        {
            for (var i = 0; i < Height; i++)
            {
                for (var j = 0; j < Width; j++)
                {
                    _grid[i, j] = new Vertex(i, j, false);
                }
            }
        }
    }
}
