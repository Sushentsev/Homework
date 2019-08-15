namespace Task_1
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// Class RobotsManager.
    /// </summary>
    public class RobotsManager : IRobotsManager
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
        /// Initializes a new instance of the <see cref="RobotsManager"/> class.
        /// </summary>
        /// <param name="filepath">Path of a file.</param>
        public RobotsManager(string filepath)
        {
            try
            {
                // Open the text file using a stream reader.
                using (var sr = new StreamReader(filepath))
                {
                    // Loading number of nodes.
                    var line = string.Empty;
                    string[] bits = line.Split(' ');
                    var numberOfNodes = int.Parse(sr.ReadLine());
                    this.graph = new bool[numberOfNodes, numberOfNodes];

                    // Loading adjacency matrix.
                    for (var i = 0; i < numberOfNodes; ++i)
                    {
                        line = sr.ReadLine();
                        bits = line.Split(' ');
                        for (var j = 0; j < numberOfNodes; ++j)
                        {
                            this.graph[i, j] = Convert.ToBoolean(int.Parse(bits[j]));
                        }
                    }

                    // Loading number of robots, starting nodes.
                    var numberOfRobots = int.Parse(sr.ReadLine());
                    this.robots = new Robot[numberOfRobots];
                    line = sr.ReadLine();
                    bits = line.Split(' ');

                    // Initializing array of robots.
                    for (var i = 0; i < numberOfRobots; ++i)
                    {
                        this.robots[i] = new Robot(int.Parse(bits[i]), this.graph);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RobotsManager"/> class.
        /// </summary>
        /// <param name="numberOfNodes">Number of nodes.</param>
        /// <param name="numberOfRobots">Number of robots.</param>
        /// <param name="graph">Adjacency matrix.</param>
        /// <param name="startNodes">Starting nodes for robots.</param>
        public RobotsManager(int numberOfNodes, int numberOfRobots, int[,] graph, int[] startNodes)
        {
            this.graph = new bool[numberOfNodes, numberOfNodes];
            this.robots = new Robot[numberOfRobots];

            for (var i = 0; i < numberOfNodes; ++i)
            {
                for (var j = 0; j < numberOfNodes; ++j)
                {
                    this.graph[i, j] = Convert.ToBoolean(graph[i, j]);
                }
            }

            for (var i = 0; i < this.robots.Length; ++i)
            {
                this.robots[i] = new Robot(startNodes[i], this.graph);
            }
        }

        /// <summary>
        /// Is there a sequence in which all the robots will be destroyed.
        /// </summary>
        /// <returns>True — exist, false — otherwise.</returns>
        public bool IsSequenceExists()
        {
            var numberOfCurrentDestroyed = 0;
            var numberOfRobots = this.robots.Length;
            var destroyedRobots = new bool[numberOfRobots];
            IEnumerable<int> intersection = this.robots[0].TeleportingNodes;

            if (numberOfRobots == 1)
            {
                return false;
            }

            for (var i = 0; i < numberOfRobots; ++i)
            {
                if (!destroyedRobots[i])
                {
                    numberOfCurrentDestroyed = 0;

                    for (var j = i + 1; j < numberOfRobots; ++j)
                    {
                        if (!destroyedRobots[j])
                        {
                            intersection = this.robots[i].TeleportingNodes.Intersect(this.robots[j].TeleportingNodes);

                            if (intersection.Any())
                            {
                                ++numberOfCurrentDestroyed;
                                destroyedRobots[j] = true;
                            }
                        }
                    }

                    if (numberOfCurrentDestroyed == 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}