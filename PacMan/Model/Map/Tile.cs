namespace PacMan
{
    public class Tile : Vertex
    {
        public const int SIZE = 7;

        public Tile(int row, int column, bool checkpoint, Direction restriction) : 
            base(row, column, false)
        {
            Row = row;
            Column = column;
            Checkpoint = checkpoint;
            Restriction = restriction;
        }

        public Tile(int row, int column, ISprite value, bool checkpoint, Direction restriction) : 
            base(row, column, value is Brick)
        {
            Row = row;
            Column = column;
            Value = value;
            Checkpoint = checkpoint;
            Restriction = restriction;
        }

        public int Row { get; }

        public int Column { get; }

        public Offset Position => new Offset(Column * SIZE, Row * SIZE);

        public ISprite Value { get; }

        public bool Checkpoint { get; }

        public Direction Restriction { get; }
    }
}
