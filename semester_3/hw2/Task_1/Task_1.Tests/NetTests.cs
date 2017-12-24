namespace Task_1.Tests
{
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Class for testing the network.
    /// </summary>
    [TestClass]
    public class NetTests
    {
        // Structure of input file:
        // First line — number of computers;
        // Second line — OS: Windows(0), Linux(1), MacOS(2), Embox(3), SafeOS(4);
        // Other lines — dependencies.

        /// <summary>
        /// A current network.
        /// </summary>
        private Network network;

        /// <summary>
        /// All computers are independent.
        /// </summary>
        [TestMethod]
        public void InfectingIndependentComputers()
        {
            this.network = new Network(Path.GetFullPath("test1.txt"));
            const int NumberOfMoves = 100;

            for (var i = 0; i <= NumberOfMoves; ++i)
            {
                this.network.MakeMove();
            }

            Assert.IsTrue(this.network.NumberOfInfectedComputers() <= 1);
        }

        /// <summary>
        /// Checking if computer infects only connecting computers.
        /// </summary>
        [TestMethod]
        public void InfectingRandomComputers()
        {
            this.network = new Network(Path.GetFullPath("test2.txt"));
            int numberOfComputers = this.network.Computers.Length;
            const int NumberOfMoves = 50;

            for (var i = 0; i < NumberOfMoves; ++i)
            {
                // Making a move.
                this.network.MakeMove();

                // Finding infected computers.
                for (var j = 0; j < numberOfComputers; ++j)
                {
                    if (this.network.Computers[j].IsInfected)
                    {
                        var numberOfConnectingInfectedComputers = 0;

                        // Finding number of all infected computers which have connection to current computer.
                        for (var k = 0; k < numberOfComputers; ++k)
                        {
                            if (this.network.Graph[j, k] && this.network.Computers[k].IsInfected)
                            {
                                ++numberOfConnectingInfectedComputers;
                            }
                        }

                        if (this.network.NumberOfInfectedComputers() >= 2)
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
            this.network = new Network(Path.GetFullPath("test3.txt"));
            const int NumberOfMoves = 100;

            for (var i = 0; i < NumberOfMoves; ++i)
            {
                this.network.MakeMove();
            }

            Assert.AreEqual(0, this.network.NumberOfInfectedComputers());
        }
    }
}
