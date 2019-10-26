using System;

namespace PacMan
{
    public class Vertex : IEquatable<Vertex>
    {
        public Vertex(int y, int x, bool isWall)
        {
            X = x;
            Y = y;
            IsWall = isWall;
        }

        public int X { get; }

        public int Y { get; }

        public bool IsWall { get; }

        public override string ToString() => $"X = {X}, Y = {Y}, Wall = {IsWall}";

        public bool Equals(Vertex other) => X == other.X && Y == other.Y;
    }
}
