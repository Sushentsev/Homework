namespace Task_1.Tests
{
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests for RobotsManager.
    /// </summary>
    [TestClass]
    public class RobotsManagerTests
    {
        // Format of input file:
        // 1) Number of nodes;
        // 2) Graph;
        // 3) Number of robots;
        // 4) Starting nodes.

        /// <summary>
        /// Field with RobotsManager.
        /// </summary>
        private RobotsManager maker;

        /// <summary>
        /// Two robots with three nodes. Loading from file.
        /// </summary>
        [TestMethod]
        public void TwoRobotsThreeNodesSequenceExistsLoadFromFile()
        {
            this.maker = new RobotsManager(Path.GetFullPath("test1.txt"));
            Assert.IsTrue(this.maker.IsSequenceExists());
        }

        /// <summary>
        /// Four robots with four nodes. Loading from file.
        /// </summary>
        [TestMethod]
        public void FourRobotsFourNodesSequenceExistsLoadFromFile()
        {
            this.maker = new RobotsManager(Path.GetFullPath("test2.txt"));
            Assert.IsTrue(this.maker.IsSequenceExists());
        }

        /// <summary>
        /// Two robots with four nodes. Loading from file.
        /// </summary>
        [TestMethod]
        public void TwoRobotsFourNodesSequenceNotExistsLoadFromFile()
        {
            this.maker = new RobotsManager(Path.GetFullPath("test3.txt"));
            Assert.IsFalse(this.maker.IsSequenceExists());
        }

        /// <summary>
        /// Only one robot. Loading from file.
        /// </summary>
        [TestMethod]
        public void OneRobotSequenceNotExistsLoadFromFile()
        {
            this.maker = new RobotsManager(Path.GetFullPath("test4.txt"));
            Assert.IsFalse(this.maker.IsSequenceExists());
        }

        /// <summary>
        /// Three robots with three nodes. Loading from file.
        /// </summary>
        [TestMethod]
        public void ThreeRobotsThreeNodesSequenceExistsLoadFromFile()
        {
            this.maker = new RobotsManager(Path.GetFullPath("test5.txt"));
            Assert.IsTrue(this.maker.IsSequenceExists());
        }

        /// <summary>
        /// Two robots with three nodes.
        /// </summary>
        [TestMethod]
        public void TwoRobotsThreeNodesSequenceExists()
        {
            const int NumberOfNodes = 3;
            int[,] graph = { { 0, 1, 0 }, { 0, 1, 0 }, { 0, 1, 0 } };
            const int NumberOfRobots = 2;
            int[] startNodes = { 0, 2 };

            this.maker = new RobotsManager(NumberOfNodes, NumberOfRobots, graph, startNodes);
            Assert.IsTrue(this.maker.IsSequenceExists());
        }

        /// <summary>
        /// Four robots with four nodes.
        /// </summary>
        [TestMethod]
        public void FourRobotsFourNodesSequenceExists()
        {
            const int NumberOfNodes = 4;
            int[,] graph = { { 0, 1, 0, 0 }, { 1, 0, 1, 0 }, { 0, 1, 0, 1 }, { 0, 0, 1, 0 } };
            const int NumberOfRobots = 4;
            int[] startNodes = { 0, 1, 2, 3 };

            this.maker = new RobotsManager(NumberOfNodes, NumberOfRobots, graph, startNodes);
            Assert.IsTrue(this.maker.IsSequenceExists());
        }

        /// <summary>
        /// Two robots with four nodes.
        /// </summary>
        [TestMethod]
        public void TwoRobotsFourNodesSequenceNotExists()
        {
            const int NumberOfNodes = 4;
            int[,] graph = { { 0, 1, 0, 0 }, { 1, 0, 1, 0 }, { 0, 1, 0, 1 }, { 0, 0, 1, 0 } };
            const int NumberOfRobots = 2;
            int[] startNodes = { 0, 3 };

            this.maker = new RobotsManager(NumberOfNodes, NumberOfRobots, graph, startNodes);
            Assert.IsFalse(this.maker.IsSequenceExists());
        }

        /// <summary>
        /// Only one robot.
        /// </summary>
        [TestMethod]
        public void OneRobotSequenceNotExists()
        {
            const int NumberOfNodes = 3;
            int[,] graph = { { 0, 1, 1 }, { 1, 0, 1 }, { 1, 1, 0 } };
            const int NumberOfRobots = 1;
            int[] startNodes = { 1 };

            this.maker = new RobotsManager(NumberOfNodes, NumberOfRobots, graph, startNodes);
            Assert.IsFalse(this.maker.IsSequenceExists());
        }

        /// <summary>
        /// Three robots with three nodes.
        /// </summary>
        [TestMethod]
        public void ThreeRobotsThreeNodesSequenceExists()
        {
            const int NumberOfNodes = 3;
            int[,] graph = { { 0, 1, 1 }, { 1, 0, 1 }, { 1, 1, 0 } };
            const int NumberOfRobots = 3;
            int[] startNodes = { 0, 1, 2 };

            this.maker = new RobotsManager(NumberOfNodes, NumberOfRobots, graph, startNodes);
            Assert.IsTrue(this.maker.IsSequenceExists());
        }
    }
}
