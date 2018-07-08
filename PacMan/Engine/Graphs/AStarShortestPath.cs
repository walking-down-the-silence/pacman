using System;
using System.Collections.Generic;

namespace PacMan
{
    /// <summary>
    /// A* algorithm for serching the shortest distance path from source to target vertex.
    /// </summary>
    public class AStarShortestPath : IShortestPathStrategy
    {
        /// <summary>
        /// Steps the AStar algorithm forward until it either fails or finds the goal node.
        /// </summary>
        /// <returns>Returns the state the algorithm finished in, Failed or GoalFound.</returns>
        public Pathway FindPath(IGraph graph, Vertex start, Vertex target)
        {
            /// System.Collections.Generic.SortedList by default does not allow duplicate items.
            /// Since items are keyed by TotalCost there can be duplicate entries per key.
            var priorityComparer = Comparer<int>.Create((x, y) => (x <= y) ? -1 : 1);
            var opened = new PriorityQueue<int, Vertex>(priorityComparer);
            var visited = new PriorityQueue<int, Vertex>(priorityComparer);

            var path = new Dictionary<Vertex, VertexInfo>();

            // Resets the AStar algorithm with the newly specified start node and goal node.
            var current = start;
            path[start] = new VertexInfo(start, null, target, 0);
            opened.Enqueue(path[start].TotalCost, start);

            // Continue searching until either failure or the goal node has been found.
            AlgorithmState state = AlgorithmState.Searching;

            while (state == AlgorithmState.Searching)
            {
                current = GetNext(opened, visited);

                if (current == null)
                {
                    state = AlgorithmState.PathDoesNotExist;
                    break;
                }

                // Remove from the open list and place on the closed list 
                // since this node is now being searched.
                visited.Enqueue(path[current].TotalCost, current);

                // Found the goal, stop searching.
                if (current.Equals(target))
                {
                    state = AlgorithmState.PathFound;
                    break;
                }

                ExtendOpened(graph, opened, visited, current, target, path);
            }

            ICollection<Vertex> vertices = ReconstructPath(current, path);
            int distance = current != null && path.ContainsKey(current) ? path[current].MovementCost : 0;

            return new Pathway(vertices, distance, state);
        }

        private static void ExtendOpened(
            IGraph graph,
            PriorityQueue<int, Vertex> opened,
            PriorityQueue<int, Vertex> visited,
            Vertex current,
            Vertex target,
            Dictionary<Vertex, VertexInfo> path)
        {
            foreach (var child in graph.GetNeighbors(current))
            {
                // If the child has already been visited (closed list) or is on
                // the open list to be searched then do not modify its movement cost
                // or estimated cost since they have already been set previously.
                if (!child.IsWall && !visited.ContainsValue(child) && !opened.ContainsValue(child))
                {
                    // Each child needs to have its movement cost set and estimated cost.
                    path[child] = new VertexInfo(child, current, target, path[current].MovementCost);
                    opened.Enqueue(path[child].TotalCost, child);
                }
            }
        }

        private static Vertex GetNext(PriorityQueue<int, Vertex> opened, PriorityQueue<int, Vertex> visited)
        {
            while (!opened.IsEmpty())
            {
                // Check the next best node in the graph by TotalCost.
                var current = opened.Dequeue();

                // This node has already been searched, check the next one.
                if (!visited.ContainsValue(current))
                {
                    return current;
                }
            }

            return default;
        }

        /// <summary>
        /// Gets the path of the last solution of the AStar algorithm.
        /// Will return a partial path if the algorithm has not finished yet.
        /// </summary>
        /// <returns>Returns null if the algorithm has never been run.</returns>
        private ICollection<Vertex> ReconstructPath(Vertex current, Dictionary<Vertex, VertexInfo> path)
        {
            if (current != null)
            {
                var next = current;
                var vertices = new List<Vertex>();

                while (next != null)
                {
                    vertices.Add(next);
                    next = path[next].Parent;
                }

                vertices.Reverse();
                return vertices;
            }

            return new Vertex[0];
        }

        private class VertexInfo
        {
            public VertexInfo(Vertex source, Vertex parent, Vertex target, int parentCost)
            {
                Source = source;
                Parent = parent;
                // distance between grid cell is estimated at 1 point
                MovementCost = parentCost + 1;
                // manhattan distance
                EstimatedCost = Math.Abs(Source.X - target.X) + Math.Abs(Source.Y - target.Y);
            }

            /// <summary>
            /// Gets of sets the source node for this info.
            /// </summary>
            public Vertex Source { get; private set; }

            /// <summary>
            /// Gets or sets the parent node to source node.
            /// </summary>
            public Vertex Parent { get; private set; }

            /// <summary>
            /// Gets the total cost for this node.
            /// f = g + h
            /// TotalCost = MovementCost + EstimatedCost
            /// </summary>
            public int TotalCost => MovementCost + EstimatedCost;

            /// <summary>
            /// Gets the movement cost for this node.
            /// This is the movement cost from this node to the starting node, or g.
            /// </summary>
            public int MovementCost { get; private set; }

            /// <summary>
            /// Gets the estimated cost for this node.
            /// This is the heuristic from this node to the goal node, or h.
            /// </summary>
            public int EstimatedCost { get; private set; }
        }
    }
}
