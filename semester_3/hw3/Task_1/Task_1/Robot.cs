namespace Task_1
{
    using System.Collections.Generic;

    /// <summary>
    /// Robot class.
    /// </summary>
    public class Robot : IRobot
    {
        /// <summary>
        /// Gets an djacency matrix.
        /// </summary>
        private bool[,] graph;

        /// <summary>
        /// Initializes a new instance of the <see cref="Robot"/> class.
        /// </summary>
        /// <param name="startNode">Robot's starting node.</param>
        /// <param name="graph">Adjacency matrix.</param>
        public Robot(int startNode, bool[,] graph)
        {
            this.graph = graph;
            this.TeleportingNodes = new List<int>();
            this.FindTeleportingNodes(startNode, new HashSet<int>());
        }

        /// <summary>
        /// Gets the list of nodes in which robot can teleport.
        /// </summary>
        public List<int> TeleportingNodes { get; private set; }

        /// <summary>
        /// Finding teleporting nodes for current node.
        /// </summary>
        /// <param name="startNode">Current node.</param>
        /// <param name="visitedNodes">HashSet of visited nodes.</param>
        private void FindTeleportingNodes(int startNode, HashSet<int> visitedNodes)
        {
            // Added starting node to visited.
            visitedNodes.Add(startNode);
            var temp = new List<int>();
            var addedNodes = 0;

            // Finding adjacent nodes.
            for (var i = 0; i < this.graph.GetLength(0); ++i)
            {
                if (this.graph[startNode, i])
                {
                    temp.Add(i);
                }
            }

            // Finding teleporting nodes and adding them to list.
            foreach (var node in temp)
            {
                for (var j = 0; j < this.graph.GetLength(0); ++j)
                {
                    if (this.graph[node, j] && !this.TeleportingNodes.Contains(j))
                    {
                        this.TeleportingNodes.Add(j);
                        ++addedNodes;
                    }
                }
            }

            // Finding teleporting for nodes which are not visited.
            if (addedNodes > 0)
            {
                for (int i = 0; i < this.TeleportingNodes.Count; ++i)
                {
                    if (!visitedNodes.Contains(this.TeleportingNodes[i]))
                    {
                        this.FindTeleportingNodes(this.TeleportingNodes[i], visitedNodes);
                    }
                }
            }
        }
    }
}
