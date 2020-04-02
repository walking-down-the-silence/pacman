using System.Collections.Generic;

namespace PacMan
{
    public static class GraphExtentions
    {
        private static (int Left, int Top) left = (-1, 0);
        private static (int Left, int Top) leftUp = (-1, -1);
        private static (int Left, int Top) up = (0, -1);
        private static (int Left, int Top) upRight = (1, -1);
        private static (int Left, int Top) right = (1, 0);
        private static (int Left, int Top) rightDown = (1, 1);
        private static (int Left, int Top) down = (0, 1);
        private static (int Left, int Top) downLeft = (-1, 1);

        private static readonly List<(int Left, int Top)> neightborsDiagonalShift = new List<(int Left, int Top)>
            {
                left,
                leftUp,
                up,
                upRight,
                right,
                rightDown,
                down,
                downLeft
            };

        private static readonly List<(int Left, int Top)> neightborsDirectShift = new List<(int Left, int Top)>
            {
                left,
                up,
                right,
                down
            };

        public static IEnumerable<Tile> GetNeighbors(this ITilemap graph, Tile node, bool includeDiagonals = false)
        {
            List<(int Left, int Top)> currentShift =
                includeDiagonals
                ? neightborsDiagonalShift
                : neightborsDirectShift;

            for (int i = 0; i < currentShift.Count; i++)
            {
                int y = node.Y + currentShift[i].Top;
                int x = node.X + currentShift[i].Left;

                if (x >= 0 && y >= 0 && x < graph.Size.Width && y < graph.Size.Height)
                {
                    yield return graph[y, x];
                }
            }
        }
    }
}
