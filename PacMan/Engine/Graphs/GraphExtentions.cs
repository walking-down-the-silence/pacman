using System.Collections.Generic;

namespace PacMan
{
    public static class GraphExtentions
    {
        private static readonly List<Offset> neightborsDiagonalShift = 
            new List<Offset>
            {
                Direction.Left.ToOffset(),
                Direction.LeftUp.ToOffset(),
                Direction.Up.ToOffset(),
                Direction.UpRight.ToOffset(),
                Direction.Right.ToOffset(),
                Direction.RightDown.ToOffset(),
                Direction.Down.ToOffset(),
                Direction.DownLeft.ToOffset()
            };

        private static readonly List<Offset> neightborsDirectShift = new List<Offset>
            {
                Direction.Left.ToOffset(),
                Direction.Up.ToOffset(),
                Direction.Right.ToOffset(),
                Direction.Down.ToOffset()
            };

        public static IEnumerable<Vertex> GetNeighbors(this IGraph graph, Vertex node, bool includeDiagonals = false)
        {
            List<Offset> currentShift =
                includeDiagonals
                ? neightborsDiagonalShift
                : neightborsDirectShift;

            for (int i = 0; i < currentShift.Count; i++)
            {
                int y = node.Y + currentShift[i].Top;
                int x = node.X + currentShift[i].Left;

                if (x >= 0 && y >= 0 && x < graph.Width && y < graph.Height)
                {
                    yield return graph[y, x];
                }
            }
        }
    }
}
