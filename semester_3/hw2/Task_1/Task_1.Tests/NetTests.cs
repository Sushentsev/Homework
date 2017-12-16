using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Task_1.Classes;

namespace Task_1.Tests
{
    [TestClass]
    public class NetTests
    {
        private Network network;

        /// Structure of input file:
        /// First line — number of computers;
        //  Second line — OS: Windows(0), Linux(1), MacOS(2), Embox(3), SafeOS(4);
        //  Other lines — dependencies.

        /// <summary>
        /// All computers are independent.
        /// </summary>
        [TestMethod]
        public void InfectingIndependentComputers()
        {
            network = new Network(Path.GetFullPath("test1.txt"));
            const int numberOfMoves = 100;

            for (var i = 0; i <= numberOfMoves; ++i)
            {
                network.MakeMove();
            }

            Assert.IsTrue(network.NumberOfInfectedComputers() <= 1);
        }

        /// <summary>
        /// Checking if computer infects only connecting computers.
        /// </summary>
        [TestMethod]
        public void InfectingRandomComputers()
        {
            network = new Network(Path.GetFullPath("test2.txt"));
            int numberOfComputers = network.Computers.Length;
            const int numberOfMoves = 50;

            for (var i = 0; i < numberOfMoves; ++i)
            {
                // Making a move.
                network.MakeMove();

                // Finding infected computers.
                for (var j = 0; j < numberOfComputers; ++j)
                {
                    if (network.Computers[j].IsInfected)
                    {
                        var numberOfConnectingInfectedComputers = 0;

                        // Finding number of all infected computers which have connection to current computer.
                        for (var k = 0; k < numberOfComputers; ++k)
                        {
                            if (network.Graph[j, k] && network.Computers[k].IsInfected)
                            {
                                ++numberOfConnectingInfectedComputers;
                            }
                        }

                        if (network.NumberOfInfectedComputers() >= 2)
                        {
                            // Because it counts itself too.
                            Assert.IsTrue(numberOfConnectingInfectedComputers >= 2);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Trying to infect computers with SafeOS.
        /// </summary>
        [TestMethod]
        public void InfectingSafeComputers()
        {
            network = new Network(Path.GetFullPath("test3.txt"));
            const int numberOfMoves = 100;

            for (var i = 0; i < numberOfMoves; ++i)
            {
                network.MakeMove();
            }

            Assert.IsTrue(network.NumberOfInfectedComputers() == 0);
        }
    }
}
