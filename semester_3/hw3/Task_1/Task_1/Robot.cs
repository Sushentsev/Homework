using System.Collections.Generic;

namespace Task_1
{
    /// <summary>
    /// Robot class.
    /// </summary>
    public class Robot : IRobot
    {
        /// <summary>
        /// List of nodes in which robot can teleport.
        /// </summary>
        public List<int> TeleportingNodes { get; private set; }

        /// <summary>
        /// Adjacency matrix.
        /// </summary>
        private bool[,] graph;

        /// <summary>
        /// List for current calculations.
        /// </summary>
        private List<int> visitedNodes;

        /// <summary>
        /// Constrcutor for robot.
        /// </summary>
        /// <param name="startNode">Robot's starting node.</param>
        /// <param name="graph">Adjacency matrix.</param>
        public Robot(int startNode, bool[,] graph)
        {
            this.graph = graph;
            TeleportingNodes = new List<int>();
            visitedNodes = new List<int>();
            FindTeleportingNodes(startNode);
        }

        /// <summary>
        /// Finding teleporting nodes for current node.
        /// </summary>
        /// <param name="startNode">Current node.</param>
        private void FindTeleportingNodes(int startNode)
        {
            // Added starting node to visited.
            visitedNodes.Add(startNode);
            var temp = new List<int>();
            var addedNodes = 0;

            // Finding adjacent nodes.
            for (var i = 0; i < graph.GetLength(0); ++i)
            {
                if (graph[startNode, i])
                {
                    temp.Add(i);
                }
            }

            // Finding teleporting nodes and adding them to list.
            foreach (var node in temp)
            {
                for (var j = 0; j < graph.GetLength(0); ++j)
                {
                    if (graph[node, j] && !TeleportingNodes.Contains(j))
                    {
                        TeleportingNodes.Add(j);
                        ++addedNodes;
                    }
                }
            }

            // Finding teleporting for nodes which are not visited.
            if (addedNodes > 0)
            {
                for (int i = 0; i < TeleportingNodes.Count; ++i)
                {
                    if (!visitedNodes.Contains(TeleportingNodes[i]))
                    {
                        FindTeleportingNodes(TeleportingNodes[i]);
                    }
                }
            }
        }
    }
}
