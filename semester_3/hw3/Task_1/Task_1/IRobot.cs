namespace Task_1
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface for robot.
    /// </summary>
    public interface IRobot
    {
        /// <summary>
        /// Gets the list of nodes in which robot can teleport.
        /// </summary>
        List<int> TeleportingNodes { get; }
    }
}
