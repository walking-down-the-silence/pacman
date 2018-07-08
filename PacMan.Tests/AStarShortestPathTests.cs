using System.Linq;
using Xunit;

namespace PacMan.Tests
{
    public class AStarShortestPathTests
    {
        [Fact]
        public void FindPath_OnGraph_ShouldFindPath()
        {
            // Arrange
            var graph = new AdjacentMatrixGraph(8, 8);
            BuildWalls(graph);
            var start = new Vertex(3, 2, false);
            var target = new Vertex(5, 1, false);
            var algorithm = new AStarShortestPath();

            // Act
            var path = algorithm.FindPath(graph, start, target);

            // Assert
            Assert.Equal(AlgorithmState.PathFound, path.State);
            Assert.Equal(start, path.First());
            Assert.Equal(target, path.Last());
        }

        private void BuildWalls(AdjacentMatrixGraph graph)
        {
            SetWall(graph, 0, 0);

            SetWall(graph, 1, 0);
            SetWall(graph, 1, 2);
            SetWall(graph, 1, 3);
            SetWall(graph, 1, 4);
            SetWall(graph, 1, 5);
            SetWall(graph, 1, 6);

            SetWall(graph, 2, 0);
            SetWall(graph, 2, 3);
            SetWall(graph, 2, 6);

            SetWall(graph, 3, 0);
            SetWall(graph, 3, 1);
            SetWall(graph, 3, 3);
            
            SetWall(graph, 4, 1);
            SetWall(graph, 4, 2);
            SetWall(graph, 4, 3);

            SetWall(graph, 5, 2);
            SetWall(graph, 5, 5);
            SetWall(graph, 5, 6);

            SetWall(graph, 6, 2);
            SetWall(graph, 6, 6);

            SetWall(graph, 7, 6);
        }

        private void SetWall(AdjacentMatrixGraph grid, int y, int x)
        {
            grid[y, x] = new Vertex(y, x, true);
        }
    }
}
