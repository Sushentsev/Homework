using Task_1.Interfaces;

namespace Task_1.Classes
{
    /// <summary>
    /// Class robotsMaker.
    /// </summary>
    public class RobotsMaker : IRobotsMaker
    {
        /// <summary>
        /// Array or robots.
        /// </summary>
        private IRobot[] robots;

        /// <summary>
        /// Adjacency matrix.
        /// </summary>
        private bool[,] graph;

        /// <summary>
        /// Constructor with loading from file.
        /// </summary>
        /// <param name="filepath"></param>
        public RobotsMaker(string filepath)
        {

        }

        /// <summary>
        /// Constructor with loading from current settings.
        /// </summary>
        /// <param name="numberOfNodes">Number of nodes.</param>
        /// <param name="numberOfRobots">Number of robots.</param>
        /// <param name="graph">Adjacency matrix.</param>
        /// <param name="startNodes">Starting nodes for robots.</param>
        public RobotsMaker(int numberOfNodes, int numberOfRobots, bool[,] graph, int[] startNodes)
        {
            graph = new bool[numberOfNodes, numberOfNodes];
            robots = new Robot[numberOfRobots];
            this.graph = graph;

            for (var i = 0; i < robots.Length; ++i)
            {
                robots[i] = new Robot(startNodes[i], this.graph);
            }
        }

        public bool IsSequenceExists()
        {
            return true;
        }
    }
}
