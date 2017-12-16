using System.Collections.Generic;

namespace Task_1.Interfaces
{
    /// <summary>
    /// Interface for robot.
    /// </summary>
    interface IRobot
    {
        /// <summary>
        /// List of nodes in which robot can teleport.
        /// </summary>
        List<int> TeleportingNodes { get; }
    }
}
