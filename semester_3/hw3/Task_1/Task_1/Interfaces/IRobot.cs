using System.Collections.Generic;

namespace Task_1.Interfaces
{
    /// <summary>
    /// Interface for robot.
    /// </summary>
    interface IRobot
    {
        /// <summary>
        /// Started node for robot.
        /// </summary>
        int StartNode { get; }

        /// <summary>
        /// List of nodes which robot can visit.
        /// </summary>
        List<int> VisitedNodes { get; }

        /// <summary>
        /// Set graph to robot.
        /// </summary>
        /// <param name="graph">Adjacency matrix.</param>
        void SetGraph(int[,] graph);
    }
}
