namespace PacMan
{
    public class FrameBase : IFrame
    {
        private readonly Color[,] _cells;
        protected const Color None = Color.None;

        protected FrameBase(Color[,] cells)
        {
            _cells = cells;
            Size = new Size(cells.GetLength(1), cells.GetLength(0));
        }

        public Color this[int y, int x] => _cells[y, x];

        public Size Size { get; protected set; }
    }
}
