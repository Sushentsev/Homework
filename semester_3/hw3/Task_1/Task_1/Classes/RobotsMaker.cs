using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Task_1.Interfaces;

namespace Task_1.Classes
{
    /// <summary>
    /// Class RobotsMaker.
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
            try
            {
                // Open the text file using a stream reader.
                using (var sr = new StreamReader(filepath))
                {
                    // Loading number of nodes.
                    var line = string.Empty;
                    string[] bits = line.Split(' ');
                    var numberOfNodes = int.Parse(sr.ReadLine());
                    graph = new bool[numberOfNodes, numberOfNodes];

                    // Loading adjacency matrix.
                    for (var i = 0; i < numberOfNodes; ++i)
                    {
                        line = sr.ReadLine();
                        bits = line.Split(' ');
                        for (var j = 0; j < numberOfNodes; ++j)
                        {
                            graph[i, j] = int.Parse(bits[j]) == 1 ? true : false;
                        }
                    }

                    //Loading number of robots, starting nodes.
                    var numberOfRobots = int.Parse(sr.ReadLine());
                    robots = new Robot[numberOfRobots];
                    line = sr.ReadLine();
                    bits = line.Split(' ');

                    // Initializing array of robots.
                    for (var i = 0; i < numberOfRobots; ++i)
                    {
                        robots[i] = new Robot(int.Parse(bits[i]), graph);
                    }

                    sr.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
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

        /// <summary>
        /// Is there a sequence in which all the robots will be destroyed.
        /// </summary>
        /// <returns>True — exist, false — otherwise.</returns>
        public bool IsSequenceExists()
        {
            var numberOfRobots = robots.Length;
            var intersection = robots[0].TeleportingNodes;

            if (numberOfRobots == 1)
            {
                return false;
            }

            // Finding intersection of teleporting nodes of all robots.
            foreach (var robot in robots)
            {
                intersection.Intersect(robot.TeleportingNodes);
            }

            if (intersection.Count == 0)
            {
                return false;
            }

            return true;
        }
    }
}
