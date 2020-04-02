using System;

namespace PacMan
{
    public class Tile : IEquatable<Tile>
    {
        public const int SIZE = 7;

        public Tile(int row, int column, bool checkpoint, Direction restriction)
        {
            Row = row;
            Column = column;
            Y = row;
            X = column;
            Checkpoint = checkpoint;
            Restriction = restriction;
            IsWall = false;
        }

        public Tile(int row, int column, ISprite value, bool checkpoint, Direction restriction)
        {
            Row = row;
            Column = column;
            Y = row;
            X = column;
            Value = value;
            Checkpoint = checkpoint;
            Restriction = restriction;
            IsWall = value is Brick;
        }

        public int Row { get; }

        public int Column { get; }

        public Offset Position => new Offset(Column * SIZE, Row * SIZE);

        public ISprite Value { get; }

        public bool Checkpoint { get; }

        public Direction Restriction { get; }

        public int X { get; }

        public int Y { get; }

        public bool IsWall { get; }

        public bool Equals(Tile other) => X == other.X && Y == other.Y;
    }
}
