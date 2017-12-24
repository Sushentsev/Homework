using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;

namespace Task_1.Tests
{
    [TestClass]
    public class RobotsManagerTests
    {
        private RobotsManager maker;

        /// Format of input file:
        /// 1) Number of nodes;
        /// 2) Graph;
        /// 3) Number of robots;
        /// 4) Starting nodes.

        /// <summary>
        /// Two robots with three nodes.
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            maker = new RobotsManager(Path.GetFullPath("test1.txt"));
            Assert.IsTrue(maker.IsSequenceExists());
        }

        /// <summary>
        /// Four robots with four nodes.
        /// </summary>
        [TestMethod]
        public void TestMethod2()
        {
            maker = new RobotsManager(Path.GetFullPath("test2.txt"));
            Assert.IsTrue(maker.IsSequenceExists());
        }

        /// <summary>
        /// Two robots with four nodes.
        /// </summary>
        [TestMethod]
        public void TestMethod3()
        {
            maker = new RobotsManager(Path.GetFullPath("test3.txt"));
            Assert.IsFalse(maker.IsSequenceExists());
        }

        /// <summary>
        /// Only one robot.
        /// </summary>
        [TestMethod]
        public void TestMethod4()
        {
            maker = new RobotsManager(Path.GetFullPath("test4.txt"));
            Assert.IsFalse(maker.IsSequenceExists());
        }

        /// <summary>
        /// Three robots with three nodes.
        /// </summary>
        [TestMethod]
        public void TestMethod5()
        {
            maker = new RobotsManager(Path.GetFullPath("test5.txt"));
            Assert.IsTrue(maker.IsSequenceExists());
        }

        /// <summary>
        /// Same as TestMethod1 but with other constructor.
        /// </summary>
        [TestMethod]
        public void TestMethod6()
        {
            const int numberOfNodes = 3;
            int[,] graph = { { 0, 1, 0 }, { 0, 1, 0 }, { 0, 1, 0 } };
            const int numberOfRobots = 2;
            int[] startNodes = { 0, 2 };

            maker = new RobotsManager(numberOfNodes, numberOfRobots, graph, startNodes);
            Assert.IsTrue(maker.IsSequenceExists());
        }

        /// <summary>
        /// Same as TestMethod2 but with other constructor.
        /// </summary>
        [TestMethod]
        public void TestMethod7()
        {
            const int numberOfNodes = 4;
            int[,] graph = { { 0, 1, 0, 0 }, { 1, 0, 1, 0 }, { 0, 1, 0, 1 }, { 0, 0, 1, 0 } };
            const int numberOfRobots = 4;
            int[] startNodes = { 0, 1, 2, 3 };

            maker = new RobotsManager(numberOfNodes, numberOfRobots, graph, startNodes);
            Assert.IsTrue(maker.IsSequenceExists());
        }

        /// <summary>
        /// Same as TestMethod3 but with other constructor.
        /// </summary>
        [TestMethod]
        public void TestMethod8()
        {
            const int numberOfNodes = 4;
            int[,] graph = { { 0, 1, 0, 0 }, { 1, 0, 1, 0 }, { 0, 1, 0, 1 }, { 0, 0, 1, 0 } };
            const int numberOfRobots = 2;
            int[] startNodes = { 0, 3 };

            maker = new RobotsManager(numberOfNodes, numberOfRobots, graph, startNodes);
            Assert.IsFalse(maker.IsSequenceExists());
        }

        /// <summary>
        /// Same as TestMethod4 but with other constructor.
        /// </summary>
        [TestMethod]
        public void TestMetho9()
        {
            const int numberOfNodes = 3;
            int[,] graph = { { 0, 1, 1 }, { 1, 0, 1 }, { 1, 1, 0 } };
            const int numberOfRobots = 1;
            int[] startNodes = { 1 };

            maker = new RobotsManager(numberOfNodes, numberOfRobots, graph, startNodes);
            Assert.IsFalse(maker.IsSequenceExists());
        }

        /// <summary>
        /// Same as TestMethod5 but with other constructor.
        /// </summary>
        [TestMethod]
        public void TestMethod10()
        {
            const int numberOfNodes = 3;
            int[,] graph = { { 0, 1, 1 }, { 1, 0, 1 }, { 1, 1, 0 } };
            const int numberOfRobots = 3;
            int[] startNodes = { 0, 1, 2 };

            maker = new RobotsManager(numberOfNodes, numberOfRobots, graph, startNodes);
            Assert.IsTrue(maker.IsSequenceExists());
        }
    }
}
